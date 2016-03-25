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
        private const string clientId = "BWVOT3CVKFPWHYN3VE23GIYE0KAMMC1HU3WZVLJEU1L0OKYB";
        private const string clientSecret = "0LRAHA4ND2DSQA0OL3SKLTGNX2NTOBL2S3D52A01SK4MBCM4";
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
