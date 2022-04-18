using System.Linq;

namespace OfflineMapDownloader.Models
{
    public class TileAddress
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public string getFileAddress(string path, string extension)
        {
            path = path.ElementAt(path.Length-1) == '\\' ? path : path + "\\";
            return $"{path}{Z}\\{X}\\{Y}.{extension}";
        }

        public string replaceAddress(string urlFormat)
        {
            return urlFormat.Replace("{x}", X.ToString()).Replace("{y}", Y.ToString()).Replace("{z}", Z.ToString());
        }
    }
}
