using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using Chronos.FoursquareJson;
using Newtonsoft.Json;

namespace Chronos
{
    public static class FoursquareClass
    {
        private const string clientId = "CB3B1EURDAQUAGZSPASA3QZX2Z0PEN3YP1MDJS0UKYNQ0ZX5";
        private const string clientSecret = "GMIF0CVLMA2I0UOLVQKTKM0DZUWJ3PX1QLX1TGWQE0BKNZLB";
        private const string url = "https://api.foursquare.com/v2/venues/";
        private const string coordinate = "ll=2.249863,102.277030";

        public static async Task<FoursquareRootObject> GetFoursquareFoodAsync()
        {
            string link = string.Format("{0}search?{1}&client_id={2}&client_secret={3}&query=food&v=20150325&openNow=true", url,coordinate,clientId,clientSecret);
            var hc = new HttpClient();
            string response = await hc.GetStringAsync(new Uri(link));

            var result = JsonConvert.DeserializeObject<FoursquareRootObject>(response);

            return result;
        }
    }
}
