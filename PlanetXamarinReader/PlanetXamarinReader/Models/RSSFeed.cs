using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PlanetXamarinReader.Models
{
    public class RSSFeed
    {
        public string title { get; set; }
        public string gravatar { get; set; }
        public string link { get; set; }
        public string pubDate { get; set; }
        public string shortDescription { get; set; }
        public string description { get; set; }

    }
}
