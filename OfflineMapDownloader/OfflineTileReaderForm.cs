// using MongoDB.Driver;
using AwesomeTiles;
using Newtonsoft.Json;
using OfflineMapDownloader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OfflineMapDownloader.MapTileReader;

namespace OfflineMapDownloader
{
    public partial class OfflineTileReaderForm : Form
    {        
        private readonly HttpClient _client = new HttpClient()
        {
            MaxResponseContentBufferSize = 1_000_000
        };

        private MapTileReader mapTileReader = new MapTileReader();
        private List<MapProfile> profiles = new List<MapProfile>();
        private ReadMapTileParam currentParameters = new ReadMapTileParam();
        private int TotalMapTiles = 0;
        public OfflineTileReaderForm()
        {
            InitializeComponent();
            profiles.Add(new MapProfile() { Name = "OSM", Extension = "png", Url = "https://tile.openstreetmap.org/{z}/{x}/{y}.png" });
            profiles.Add(new MapProfile() { Name = "MapBox GL", Extension = "pbf", Url = "https://api.mapbox.com/v4/mapbox.mapbox-streets-v8,mapbox.mapbox-terrain-v2/{z}/{x}/{y}.vector.pbf?sku=101xhOEco1UOc&access_token=pk.eyJ1IjoiZmFyc2hhZGJheWF0IiwiYSI6ImNsMXJ6c3dnMzB2bDYzaXB0czA5aTQ0NDYifQ.4I4Bst2KXt42UbjIt4gyWg" });

            foreach (var item in profiles)
            {
                mapProfileComboBox.Items.Add(item.Name);
            }

            // mapProfileComboBox.Text = "OSM";
            mapProfileComboBox.SelectedIndex = 0;
        }

        private void addRowParamButton_Click(object sender, EventArgs e)
        {
            rowParamPanel.Visible = true;
            leftBottomLatTextBox.Focus();
        }

        private void cancelAddRowParamButton_Click(object sender, EventArgs e)
        {
            rowParamPanel.Visible = false;
        }

        private void mapProfileComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var map = profiles.Find(p => p.Name == mapProfileComboBox.Text);
            if(map != null)
            {
                extensionTextBox.Text = map.Extension;
                mapUrlTextBox.Text = map.Url;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorLogDataGridView.Rows.Clear();
            int r = 0;
            foreach (var error in currentParameters.Log.Where(d => d.Value != ""))
            {
                Tile tile = new Tile(error.Key);
                var endpointUrl = currentParameters.MapUrl
                .Replace("{Z}", tile.Zoom.ToString(), StringComparison.InvariantCultureIgnoreCase)
                .Replace("{X}", tile.X.ToString(), StringComparison.InvariantCultureIgnoreCase)
                .Replace("{Y}", tile.Y.ToString(), StringComparison.InvariantCultureIgnoreCase);
                
                errorLogDataGridView.Rows.Add(++r, tile.ToString(), error.Value, endpointUrl);
            }            
        }

        private void copyOSMMapButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(outputTextBox.Text == "" || Directory.Exists(outputTextBox.Text) == false)
                {
                    MessageBox.Show("Path not Exists...");
                } else
                {
                    var filePath = outputTextBox.Text;
                    filePath = filePath.ElementAt(filePath.Length - 1) == '\\' ? filePath : filePath + "\\";
                    File.WriteAllBytes(filePath + "openlayer.zip", Properties.Resources.openlayers);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private async void calculateTotalTileButton_Click(object sender, EventArgs e)
        {
            initMapTileReaderParameters();
            await mapTileReader.CalculateTotalTile(currentParameters);
            loadPyramidIntoGrid(currentParameters.PyramidBounds);
        }        

        public string localFilePath(Tile tile, string filePath, string fileExtension)
        {
            filePath = filePath.ElementAt(filePath.Length - 1) == '\\' ? filePath : filePath + "\\";
            filePath = $"{filePath}{tile.Zoom}\\{tile.X}\\{tile.Y}.{fileExtension}";
            string? directory = Path.GetDirectoryName(filePath);
            if (directory != null)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath) ?? "");
            }
            return filePath;
        }

        private void initMapTileReaderParameters()
        {
            List<PyramidBound> pyramidBounds = new List<PyramidBound>();
            foreach (DataGridViewRow row in pyramidDataGridView.Rows)
            {
                if (row.Cells["ColumnRow"].Value != null && row.Cells["ColumnLeftBottomLat"].Value != null && row.Cells["ColumnLeftBottomLon"].Value != null &&
                    row.Cells["ColumnTopRightLat"].Value != null && row.Cells["ColumnTopRightLon"].Value != null &&
                    row.Cells["ColumnZoomFrom"].Value != null && row.Cells["ColumnZoomTo"].Value != null)
                {
                    pyramidBounds.Add(new PyramidBound()
                    {
                        LeftBottomLat = double.Parse(row.Cells["ColumnLeftBottomLat"].Value.ToString() ?? "0"),
                        LeftBottomLon = double.Parse(row.Cells["ColumnLeftBottomLon"].Value.ToString() ?? "0"),
                        TopRightLat = double.Parse(row.Cells["ColumnTopRightLat"].Value.ToString() ?? "0"),
                        TopRightLon = double.Parse(row.Cells["ColumnTopRightLon"].Value.ToString() ?? "0"),
                        ZoomFrom = int.Parse(row.Cells["ColumnZoomFrom"].Value.ToString() ?? "0"),
                        ZoomTo = int.Parse(row.Cells["ColumnZoomTo"].Value.ToString() ?? "0"),
                        TotalTile = int.Parse(row.Cells["ColumnTotalTile"].Value?.ToString() ?? "0")
                    });
                }
            }

            currentParameters = new ReadMapTileParam()
            {
                MapName = mapProfileComboBox.Text,
                PyramidBounds = pyramidBounds,
                OutputPath = outputTextBox.Text,
                FileExtention = extensionTextBox.Text,
                CallbackFunction = readTileCallback,
                Delay = int.Parse(delayTextBox.Text),
                Log = currentParameters?.Log ?? new Dictionary<ulong, string>(),
                MapUrl = mapUrlTextBox.Text
            };
        }

        bool? taskStarted = false;
        private async void startReadButton_Click(object sender, EventArgs e)
        {
            if(taskStarted == false)
            {
                addRowParamButton.Enabled = false;
                loadConfigButton.Enabled = false;
                calculateTotalTileButton.Enabled = false;
                pyramidDataGridView.Enabled = false;
                taskStarted = true;
                startReadButton.Text = "Stop";
                initMapTileReaderParameters();
                this.TotalMapTiles = await mapTileReader.CalculateTotalTile(currentParameters);
                loadPyramidIntoGrid(currentParameters.PyramidBounds);
                await mapTileReader.ReadMapTiles(currentParameters);
                taskStarted = false;
                startReadButton.Text = currentParameters.Log?.Count() > 0 ? "Resume" : "Start";
                addRowParamButton.Enabled = true;
                loadConfigButton.Enabled = true;
                calculateTotalTileButton.Enabled = true;
                pyramidDataGridView.Enabled = true;
            } else
            {
                currentParameters.IsCancled = true;
                taskStarted = null;
            }
        }

        private async void readTileCallback(Task<TileStatus> obj)
        {
            int count = (await obj).Count;
            int x = (await obj).Tile?.X ?? 0;
            int y = (await obj).Tile?.Y ?? 0;
            int z = (await obj).Tile?.Zoom ?? 0;
            int error = (await obj).TotalError;
            int percent = (int)(100 * count / this.TotalMapTiles);
            statusLabel.Text = $"{count:000000} of {this.TotalMapTiles:000000}({percent: 00}%) \t  X:{x:000},Y:{y:000},Z:{z:000} \t Total Error:{error}" ;
            readProgressBar.Value = percent;
        }

        private void addToGridButton_Click(object sender, EventArgs e)
        {
            pyramidDataGridView.Rows.Add(pyramidDataGridView.Rows.Count+1 , 
                double.Parse(leftBottomLatTextBox.Text),
                double.Parse(leftBottomLonTextBox.Text),
                double.Parse(topRightLatTextBox.Text),
                double.Parse(topRightLonTextBox.Text),
                int.Parse(zoomFromTextBox.Text),
                int.Parse(zoomToTextBox.Text)
                );
            rowParamPanel.Visible = false;
        }

        private async void saveConfigButton_Click(object sender, EventArgs e)
        {
            initMapTileReaderParameters();
            await mapTileReader.CalculateTotalTile(currentParameters);
            loadPyramidIntoGrid(currentParameters.PyramidBounds);
            string json = JsonConvert.SerializeObject(currentParameters);
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, json);
            }
        }
        private void loadConfigButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string json = File.ReadAllText(openFileDialog1.FileName);
                File.WriteAllText(saveFileDialog1.FileName, json);
                currentParameters = JsonConvert.DeserializeObject<ReadMapTileParam>(json) ?? new ReadMapTileParam();
                outputTextBox.Text = currentParameters.OutputPath;
                mapProfileComboBox.Text = currentParameters.MapName;
                currentParameters.CallbackFunction = readTileCallback;
                pyramidDataGridView.Rows.Clear();
                loadPyramidIntoGrid(currentParameters.PyramidBounds);
                if(currentParameters.Log?.Count() > 0)
                {
                    if( MessageBox.Show("Download from the beginning?","", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        currentParameters.Log.Clear();
                    }
                }
                startReadButton.Text = currentParameters.Log?.Count() > 0 ? "Resume" : "Start";
            }
        }

        private void loadPyramidIntoGrid(List<PyramidBound> pyramidBounds)
        {
            pyramidDataGridView.Rows.Clear();
            foreach (var pyramidBound in pyramidBounds)
            {                
                pyramidDataGridView.Rows.Add(pyramidDataGridView.Rows.Count,
                 pyramidBound.LeftBottomLat,
                 pyramidBound.LeftBottomLon,
                 pyramidBound.TopRightLat,
                 pyramidBound.TopRightLon,
                 pyramidBound.ZoomFrom,
                 pyramidBound.ZoomTo,
                 pyramidBound.TotalTile
                );
            }         
        }



        /* Old Code */

        private async void button1_Click(object sender, EventArgs e)
        {
            MapTileReader.urlFormat = mapUrlTextBox.Text;
            MapTileReader.outputPath = outputTextBox.Text;
            MapTileReader.fileExtention = extensionTextBox.Text;
            for (int i = int.Parse(fromTextBox.Text); i <= int.Parse(toTextBox.Text); i++)
            {
                var lines = File.ReadLines(addressFormatTextBox.Text.Replace("{n}", i.ToString())).ToList();
                List<TileEntity> tileAddresses = new List<TileEntity>();
                for (int l = 1; l < lines.Count(); l++)
                {
                    var items = Regex.Replace(lines[l].Replace(".png:", ""), @"\s+", " ").Split(" ");
                    var xyz = items[0].Split("/");
                    tileAddresses.Add(new TileEntity()
                    {
                        Z = int.Parse(xyz[0]),
                        X = int.Parse(xyz[1]),
                        Y = int.Parse(xyz[2]),
                        LeftEdgeLongitude = decimal.Parse(items[1]),
                        RightEdgeLongitude = decimal.Parse(items[2]),
                        TopEdgeLatitude = decimal.Parse(items[3]),
                        BottomEdgeLatitude = decimal.Parse(items[4]),
                    });

                }
                await fetchTilesAsync(tileAddresses);
                //var result = await MapTileReader.DownloadUrlsAsync(tileAddresses, int.Parse(maxLimitTextBox.Text));
                //foreach (var tile in result)
                //{
                //    tile.tile.getFileAddress("", "");
                //}
            }
        }

        async Task fetchTilesAsync(List<TileEntity> tileAddresses)
        {
            List<TileAddress> errorTile = new List<TileAddress>();
            foreach (var tileAddress in tileAddresses)
            {
                try
                {
                    // statusLabel.Text = tileAddress.Z.ToString()+"/"+ tileAddress.X.ToString()+"/"+ tileAddress.Y.ToString();
                    string url = tileAddress.replaceAddress(urlFormat);
                    using (var response = await _client.GetAsync(url).ConfigureAwait(false))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            continue;
                        }
                        //return (tileAddress, false);
                        string filePath = tileAddress.getFileAddress(outputPath, fileExtention);
                        if (Directory.Exists(Path.GetDirectoryName(filePath)) == false)
                        {
                            String? directory = Path.GetDirectoryName(filePath);
                            if (directory != null)
                            {
                                Directory.CreateDirectory(Path.GetDirectoryName(filePath) ?? "");
                            }
                        }
                        var data = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                        await File.WriteAllBytesAsync(filePath, data);
                        await Task.Delay(1);
                    }
                }
                catch (Exception x)
                {
                    errorTile.Add(tileAddress);
                }
            }
            return;

        }

        private async void button5_Click(object sender, EventArgs e)
        {
            var zoom = 10;
            /* https://egorikas.com/download-open-street-tiles-for-offline-using/ */
            // 36.65012764798955, 48.44049164708894
            var leftBottom = Tile.CreateAroundLocation(double.Parse("36.65012764798955"), double.Parse("48.44049164708894"), zoom);
            // 36.689956293240485, 48.58772807584379
            var topRight = Tile.CreateAroundLocation(double.Parse("36.689956293240485"), double.Parse("48.58772807584379"), zoom);

            var minX = Math.Min(leftBottom.X, topRight.X);
            var maxX = Math.Max(leftBottom.X, topRight.X);

            var minY = Math.Min(leftBottom.Y, topRight.Y);
            var maxY = Math.Max(leftBottom.Y, topRight.Y);

            var tiles = new TileRange(minX, minY, maxX, maxY, zoom);
            var outputPath = outputTextBox.Text;
            var fileExtention = extensionTextBox.Text;

            foreach (var tile in tiles)
            {
                var endpointUrl = $"http://a.tile.openstreetmap.org/{zoom}/{tile.X}/{tile.Y}.png";
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, endpointUrl);
                requestMessage.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.75 Safari/537.36");
                var response = await _client.SendAsync(requestMessage);
                using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                {
                    string tileToWriteTo = localFilePath(tile, outputPath, fileExtention);
                    using (Stream streamToWriteTo = File.Open(tileToWriteTo, FileMode.Create))
                    {
                        await streamToReadFrom.CopyToAsync(streamToWriteTo);
                    }
                }
                await Task.Delay(100);
            }
        }

        





        //private bool addTile(TileAddress tile)
        //{
        //    const string connectionString = "mongodb://localhost:27017";

        //    // Create a MongoClient object by using the connection string
        //    var client = new MongoClient(connectionString);

        //    //Use the MongoClient to access the server
        //    var database = client.GetDatabase("test");

        //    //get mongodb collection
        //    var collection = database.GetCollection<TileEntity>("tiles");
        //    await collection.InsertOneAsync(new Entity { Name = "Jack" });
        //}
    }
}
