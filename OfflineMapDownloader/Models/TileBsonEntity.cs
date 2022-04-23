using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OfflineMapDownloader.Models
{
    public class TileBsonEntity: TileAddress
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public ulong TileID { get; set; }        
        public BsonBinaryData? TilePBF { get; set; }
    }
}
