using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetXamarinReader.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace PlanetXamarinReader.Services
{
    class RSSFeedAPIService
    {
        private string PlanetXamarinRSS_URLBase = "https://www.enriqueramos.info/rssfeed/api/planetxamarin";
        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<RSSFeed>> GetPlanetXamarinRSSFeed()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var json = await client.GetStringAsync(PlanetXamarinRSS_URLBase);

                ResponseAPIModel ResponseAPI = JsonConvert.DeserializeObject<ResponseAPIModel>(json);

                return ResponseAPI.data;
            }
        }
    }
}
