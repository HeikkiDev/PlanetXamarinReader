using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetXamarinReader.Models
{
    public class ResponseAPIModel
    {
        public bool code { get; set; }
        public int status { get; set; }
        public object message { get; set; }
        public List<RSSFeed> data { get; set; }
    }
}
