﻿namespace OfflineMapDownloader.Models
{
    public  class TileEntity : TileAddress
    {
        public decimal LeftEdgeLongitude { get; set; }
        public decimal RightEdgeLongitude { get; set; }
        public decimal TopEdgeLatitude { get; set; }
        public decimal BottomEdgeLatitude { get; set; }
    }
}
