﻿using AwesomeTiles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineMapDownloader.Models
{
    public class PyramidBound
    {
        public double LeftBottomLat { get; set; }
        public double LeftBottomLon { get; set; }
        public double TopRightLat { get; set; }
        public double TopRightLon { get; set; }
        public int ZoomFrom { get; set; }
        public int ZoomTo { get; set; }
        public int TotalTile { get; set; }
    }
    public class ReadMapTileParam
    {
        public string MapName { get; set; } = "";
        public List<PyramidBound> PyramidBounds { get; set; } = new List<PyramidBound>();
        public string OutputPath { get; set; } = "";
        public string MongoDBSetting { get; set; } = "";
        public string FileExtention { get; set; } = "";
        /// <summary>
        /// ex: "http://a.tile.openstreetmap.org/{Z}/{X}/{Y}.png"
        /// https://api.mapbox.com/v4/mapbox.mapbox-streets-v8,mapbox.mapbox-terrain-v2/{Z}/{X}/{Y}.vector.pbf?sku=101xhOEco1UOc&access_token=pk.eyJ1IjoiZmFyc2hhZGJheWF0IiwiYSI6ImNsMXJ6c3dnMzB2bDYzaXB0czA5aTQ0NDYifQ.4I4Bst2KXt42UbjIt4gyWg
        /// </summary>
        public string MapUrl { get; set; } = "";
        [JsonIgnore]
        public Action<Task<TileStatus>>? CallbackFunction { get; set; }
        public int Delay { get; set; } = 100;
        public int BatchSize { get; set; } = 10;
        [JsonIgnore]
        public bool IsCancled = false;
        public Dictionary<ulong, string> Log { get; set; } = new Dictionary<ulong, string>();
        [JsonIgnore]
        public int ErrorCount { get; set; }
        [JsonIgnore]
        public int FetchCount { get; set; }
        [JsonIgnore]
        public DateTime StartDateTime { get; set; }
    } 

    public class TileStatus
    {
        public Tile? Tile { get; set; }
        public int TotalError { get; set; }
        public int FetchCount { get; set; }
        public int RPS { get; set; }
    }
}
