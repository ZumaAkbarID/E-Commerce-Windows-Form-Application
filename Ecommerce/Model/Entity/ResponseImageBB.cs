using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Model.Entity
{
    public class ResponseImageBB
    {
        public ImageData data { get; set; }
        public bool success { get; set; }
        public int status { get; set; }
    }

    public class ImageData
    {
        public string id { get; set; }
        public string title { get; set; }
        public string url_viewer { get; set; }
        public string url { get; set; }
        public string display_url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string size { get; set; }
        public string time { get; set; }
        public string expiration { get; set; }
        public ImageInfo image { get; set; }
        public ImageInfo thumb { get; set; }
        public ImageInfo medium { get; set; }
        public string delete_url { get; set; }
    }

    public class ImageInfo
    {
        public string filename { get; set; }
        public string name { get; set; }
        public string mime { get; set; }
        public string extension { get; set; }
        public string url { get; set; }
    }

}
