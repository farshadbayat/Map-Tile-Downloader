using AwesomeTiles;
using MongoDB.Driver;
using Newtonsoft.Json;
using OfflineMapDownloader.Models;
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

		private int current = 0;

		static readonly HttpClient _client = new HttpClient
		{
			MaxResponseContentBufferSize = 1_000_000
		};
		private IMongoDatabase _database = null;
		

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
					this.current = 0;
					List<Task> tasks = new List<Task>();
					foreach (var tile in tiles)
					{						

						if(param.IsCancled == false)
                        {
							if (param.Log.ContainsKey(tile.Id) == true && param.Log[tile.Id] == "")
							{
								this.current++;
								continue;
							} else
                            {
								tasks.Add(fetchTileAndSave(tile, param, current));
								current++;
								/* Parallel with BatchSize Degree */
								while (tasks.Count > param.BatchSize)
                                {
									await Task.WhenAny(tasks);
									tasks.RemoveAll(t => t.Status == TaskStatus.RanToCompletion);
								}
                                /* Batch with BatchSize Windowing */
                                /* if (tasks.Count % param.BatchSize == 0)
                                {
                                    await Task.WhenAll(tasks);
                                } */

                                if (param.Delay > 0)
								{
									await Task.Delay(param.Delay);
								}
							}							
                        } else
                        {
							while (tasks.Count > 0)
							{
								await Task.WhenAny(tasks);
								tasks.RemoveAll(t => t.Status == TaskStatus.RanToCompletion);
							}
							string json = JsonConvert.SerializeObject(param);
							File.WriteAllText(param.OutputPath+"history.mfc", json);
							param.IsCancled = false;
							return;
                        }
					}
				}
			}            
		}


		private async Task fetchTileAndSave(Tile tile, ReadMapTileParam param, int current)
        {
			var endpointUrl = param.MapUrl
				.Replace("{Z}", tile.Zoom.ToString(), StringComparison.InvariantCultureIgnoreCase)
				.Replace("{X}", tile.X.ToString(), StringComparison.InvariantCultureIgnoreCase)
				.Replace("{Y}", tile.Y.ToString(), StringComparison.InvariantCultureIgnoreCase);
			HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, endpointUrl);
			requestMessage.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.75 Safari/537.36");
            try
            {
				var response = await _client.SendAsync(requestMessage);

				using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
				{
					if (param.OutputPath != "")
					{
						streamToReadFrom.Position = 0;
						string localFilePath = tile.toLocalFilePath(param.OutputPath, param.FileExtention);
						using (Stream streamToWriteTo = File.Open(localFilePath, FileMode.Create))
						{
							await streamToReadFrom.CopyToAsync(streamToWriteTo);
							param.Log.Add(tile.Id, String.Empty);
						}
					}
					if (param.MongoDBSetting != "")
					{
						streamToReadFrom.Position = 0;
						if (this._database == null)
						{
							var mongoParams = param.MongoDBSetting.Split(";");
							var client = new MongoClient(mongoParams[0]);
							this._database = client.GetDatabase(mongoParams[1]);
						}						
						MemoryStream ms = new MemoryStream();
						streamToReadFrom.CopyTo(ms);
						var tilePbf = new TileBsonEntity()
						{
							X = tile.X,
							Y = tile.Y,
							Z = tile.Zoom,
							TileID = tile.Id,
							TilePBF = new MongoDB.Bson.BsonBinaryData(ms.ToArray())
						};
						var collection = _database.GetCollection<TileBsonEntity>("OsmMapPBF");
						await collection.InsertOneAsync(tilePbf);
					}
				}
				Debug.WriteLine("Complated with Successful" + tile.Id.ToString());
			}
            catch (Exception e)
            {
				Debug.WriteLine("Complated with Error" + tile.Id.ToString());
				param.Log.Add(tile.Id, e?.InnerException?.ToString() ?? "");
				param.ErrorCount++;
			}

			await semaphoreSlim.WaitAsync();
			try
			{
				if (param.CallbackFunction != null)
				{
					param.CallbackFunction(Task.FromResult(new TileStatus() { 
						 Count = current,						
						 Tile= tile,
						 TotalError = param.ErrorCount
					}));
				}
			}
			finally
			{
				semaphoreSlim.Release();
			}
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
