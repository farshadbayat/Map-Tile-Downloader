using AwesomeTiles;
using MongoDB.Driver;
using Newtonsoft.Json;
using OfflineMapDownloader.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 * https://www.tabsoverspaces.com/233599-how-to-download-bunch-of-urls-efficiently-asynchronously 
 * https://wiki.openstreetmap.org/wiki/Slippy_map_tilenames
 */
namespace OfflineMapDownloader
{
    public  class MapTileReader
    {
		public static string urlFormat = "";
		public static string outputPath = "";
		public static string fileExtention = "png";
		static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);
		static readonly RestClient _client = new RestClient();
		private IMongoDatabase? _database = null;		

		public Task<int> CalculateTotalTile(ReadMapTileParam param)
        {
			int total = 0;
            foreach (var pyramidBound in param.PyramidBounds)
			{
				pyramidBound.TotalTile = 0;
				for (int zoom = pyramidBound.ZoomFrom; zoom <= pyramidBound.ZoomTo; zoom++)
				{
					var leftBottom = Tile.CreateAroundLocation(pyramidBound.LeftBottomLat, pyramidBound.LeftBottomLon, zoom);
					var topRight = Tile.CreateAroundLocation(pyramidBound.TopRightLat, pyramidBound.TopRightLon, zoom);

					var minX = Math.Min(leftBottom.X, topRight.X);
					var maxX = Math.Max(leftBottom.X, topRight.X);

					var minY = Math.Min(leftBottom.Y, topRight.Y);
					var maxY = Math.Max(leftBottom.Y, topRight.Y);
					var tiles = new TileRange(minX, minY, maxX, maxY, zoom);
					pyramidBound.TotalTile += tiles.Count();
				}
				total += pyramidBound.TotalTile;
			}
            return Task.FromResult(total);
        }


        /* https://egorikas.com/download-open-street-tiles-for-offline-using/ */
        public async Task ReadMapTiles(ReadMapTileParam param)
        {
			param.FetchCount = 0;
			param.ErrorCount = 0;
			param.StartDateTime = DateTime.Now;
			foreach (var pyramidBound in param.PyramidBounds)
            {
				for (int zoom = pyramidBound.ZoomFrom; zoom <= pyramidBound.ZoomTo; zoom++)
				{
					var leftBottom = Tile.CreateAroundLocation(pyramidBound.LeftBottomLat, pyramidBound.LeftBottomLon, zoom);
					var topRight = Tile.CreateAroundLocation(pyramidBound.TopRightLat, pyramidBound.TopRightLon, zoom);

					var minX = Math.Min(leftBottom.X, topRight.X);
					var maxX = Math.Max(leftBottom.X, topRight.X);

					var minY = Math.Min(leftBottom.Y, topRight.Y);
					var maxY = Math.Max(leftBottom.Y, topRight.Y);
					var tiles = new TileRange(minX, minY, maxX, maxY, zoom);					
					List<Task> tasks = new List<Task>();
					foreach (var tile in tiles)
					{						

						if(param.IsCancled == false)
                        {
							if (param.Log.ContainsKey(tile.Id) == true && param.Log[tile.Id] == "")
							{
								param.FetchCount++;
								continue;
							} else
                            {
								tasks.Add(fetchTileAndSave(tile, param));
								param.FetchCount++;
								/* Parallel with BatchSize Degree */
								while (tasks.Count > param.BatchSize)
                                {
									await Task.WhenAny(tasks);
									tasks.RemoveAll(t => t.Status == TaskStatus.RanToCompletion);
								}
                                if (param.Delay > 0)
								{
									await Task.Delay(param.Delay);
								}
							}							
                        } else
                        {
							/* Wait to Finished Task */
							while (tasks.Count > 0)
							{
								await Task.WhenAny(tasks);
								tasks.RemoveAll(t => t.Status == TaskStatus.RanToCompletion);
							}
							string json = JsonConvert.SerializeObject(param);
							File.WriteAllText(param.OutputPath + "history.mfc", json);
							param.IsCancled = false;
							return;
                        }
					}
				}
			}            
		}

		private async Task fetchTileAndSave(Tile tile, ReadMapTileParam param)
        {
			var endpointUrl = param.MapUrl
				.Replace("{Z}", tile.Zoom.ToString(), StringComparison.InvariantCultureIgnoreCase)
				.Replace("{X}", tile.X.ToString(), StringComparison.InvariantCultureIgnoreCase)
				.Replace("{Y}", tile.Y.ToString(), StringComparison.InvariantCultureIgnoreCase);
			HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, endpointUrl);
			requestMessage.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.75 Safari/537.36");
            try
            {

				var request = new RestRequest(endpointUrl, Method.Get);
				var response = await _client.ExecuteAsync(request);
				if (response.RawBytes != null)
				{					
					if (param.OutputPath != "")
					{
						string localFilePath = tile.toLocalFilePath(param.OutputPath, param.FileExtention);
						await File.WriteAllBytesAsync(localFilePath, response.RawBytes);						
					}
					if (param.MongoDBSetting != "")
					{						
						if (this._database == null)
						{
							var mongoParams = param.MongoDBSetting.Split(";");
							var client = new MongoClient(mongoParams[0]);
							this._database = client.GetDatabase(mongoParams[1]);
						}						
						var tilePbf = new TileBsonEntity()
						{
							X = tile.X,
							Y = tile.Y,
							Z = tile.Zoom,
							TileID = tile.Id,
							TilePBF = new MongoDB.Bson.BsonBinaryData(response.RawBytes)
						};
						var collection = _database.GetCollection<TileBsonEntity>("OsmMapPBF");
						await collection.InsertOneAsync(tilePbf);
					}
					param.Log.Add(tile.Id, String.Empty);
				}				
			}
            catch (Exception e)
            {				
				param.ErrorCount++;
				param.Log.Add(tile.Id, e?.InnerException?.ToString() ?? "");
			}

			int totalSeconds = (int)(DateTime.Now - param.StartDateTime).TotalSeconds;
			if (param.CallbackFunction != null && totalSeconds > 0)
			{
				param.CallbackFunction(Task.FromResult(new TileStatus()
				{
					Tile = tile,
					FetchCount = param.FetchCount,
					TotalError = param.ErrorCount,
					RPS = (int)(param.FetchCount / totalSeconds)
				}));
			}

			//await semaphoreSlim.WaitAsync();
			//try
			//{
			//	if (param.CallbackFunction != null)
			//	{
			//		param.CallbackFunction(Task.FromResult(new TileStatus() { 
			//			 Count = current,						
			//			 Tile= tile,
			//			 TotalError = param.ErrorCount
			//		}));
			//	}
			//}
			//finally
			//{
			//	semaphoreSlim.Release();
			//}
		}


		//public static async Task<IEnumerable<(TileAddress tile, bool successful)>> DownloadUrlsAsync(IEnumerable<TileAddress> urls, int batchSize)
		//{
		//	var resultList = new List<(TileAddress tile, bool successful)>();
		//	int numberOfBatches = (int)Math.Ceiling((double)urls.Count() / batchSize);
		//	Console.WriteLine("Download Start.");
		//	for (int i = 0; i < numberOfBatches; i++)
		//	{
		//		var tileBatch = urls.Skip(i * batchSize).Take(batchSize);
		//		var tasks = tileBatch.Select(tile => DownloadUrlHelperAsync(_client, tile));
		//		resultList .AddRange(await Task.WhenAll(tasks));
		//		Console.WriteLine($"#Downloaded = {0} %Progress = {1}.", (i+1) * batchSize, Math.Ceiling((decimal)numberOfBatches/(i+1)));
		//	}
		//	return resultList;

		//	//using (var semaphore = new SemaphoreSlim(limit, limit))
		//	//{
		//	//	IEnumerable<Task<(TileAddress tile, bool successful)>> tasksQuery = urls.Select(url => DownloadUrlHelperAsync(url, semaphore, _client));
		//	//	var downloadTasks = tasksQuery.ToList();
		//	//	var resultList = new List<(TileAddress tile, bool successful)>();
		//	//	while (downloadTasks.Any())
		//	//	{
		//	//		var finishedTask = await Task.WhenAny(downloadTasks);
		//	//		downloadTasks.Remove(finishedTask);
		//	//		resultList.Add( await finishedTask);
		//	//	}

		//	//	return resultList;
		//	//	//await Task.WhenAll(downloadTasks).ConfigureAwait(false);
		//	//	//return tasks.Select(x => x.Result).ToArray();
		//	//}			
		//}

		//static async Task<(TileAddress tile, bool successful)> DownloadUrlHelperAsync(HttpClient client, TileAddress tileAddress)
		//{			
		//	try
		//	{
		//		string url = tileAddress.replaceAddress(urlFormat);
		//		using (var response = await client.GetAsync(url).ConfigureAwait(false))
		//		{
		//			if (!response.IsSuccessStatusCode)
		//				return (tileAddress, false);
		//			string filePath = tileAddress.getFileAddress(outputPath, fileExtention);
		//			var data = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
		//			await File.WriteAllBytesAsync(filePath, data);
		//			return (tileAddress, true);
		//		}
		//	} catch
  //          {
		//		return (tileAddress, false);
		//	}
		//	finally
		//	{				
		//	}
		//}

		//static async Task<(TileAddress tile, bool successful)> DownloadUrlHelperAsync(HttpClient client, TileAddress tileAddress, SemaphoreSlim semaphore)
		//{
		//	await semaphore.WaitAsync().ConfigureAwait(false);
		//	try
		//	{
		//		string url = tileAddress.replaceAddress(urlFormat);
		//		using (var response = await client.GetAsync(url).ConfigureAwait(false))
		//		{
		//			if (!response.IsSuccessStatusCode)
		//				return (tileAddress, false);
		//			string filePath = tileAddress.getFileAddress(outputPath, fileExtention);
		//			var data = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
		//			await File.WriteAllBytesAsync(filePath, data);
		//			return (tileAddress, true);
		//		}
		//	}
		//	finally
		//	{
		//		semaphore.Release();
		//	}
		//}
	}


	static class Extensions
    {
		public static string toLocalFilePath(this Tile tile, string filePath, string fileExtension)
		{
			filePath = filePath.ElementAt(filePath.Length - 1) == '\\' ? filePath : filePath + "\\";
			filePath = $"{filePath}data\\{tile.Zoom}\\{tile.X}\\{tile.Y}.{fileExtension}";
			string? directory = Path.GetDirectoryName(filePath);
			if (directory != null)
			{
				Directory.CreateDirectory(Path.GetDirectoryName(filePath) ?? "");
			}
			return filePath;
		}
	}
}
