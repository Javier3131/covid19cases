using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class API
    {
        private static string server = "https://covid-19-statistics.p.rapidapi.com/";
        private static string rapidApiKey = "62751de94cmshd3fcb1f05714859p1c6996jsn73fec30aaa7a";
        private static string rapidApiHost = "covid-19-statistics.p.rapidapi.com";

        public static HttpResponseMessage Get(string api)
        {
            string BaseAddress = server + api;

            HttpResponseMessage response;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseAddress);

            client.DefaultRequestHeaders.Add("x-rapidapi-key", rapidApiKey);
            client.DefaultRequestHeaders.Add("x-rapidapi-host", rapidApiHost);
            
            response = client.GetAsync("").Result;

            return response;
        }

    }
}
