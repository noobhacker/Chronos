﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace Chronos
{
    public static class WebAPIClass
    {
        public const string WebAPIAddress = "http://localhost:17461/api/";
        public static async Task<bool> PostJsonToServerAsync(object json, string target)
        {
            var subjectJson = JsonConvert.SerializeObject(json);
            var client = new HttpClient();
            var HttpContent = new HttpStringContent(subjectJson);
            HttpContent.Headers.ContentType = new Windows.Web.Http.Headers.HttpMediaTypeHeaderValue("application/json");

            var returnValue = await client.PostAsync(new Uri(WebAPIAddress + target), HttpContent);

            return true;
        }

        public static async Task<string> GetJsonFromServerAsync(string target, string targetId)
        {
            var client = new HttpClient();
            string address = WebAPIAddress + target;
            if(targetId != "")
               address += "/" + targetId;

            string result = await client.GetStringAsync(new Uri(address));

            return result;
        }
    }
}
