using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.Caching;
using System.Text.Json;

namespace ProxyCacheConsole
{
    public class JCDecauxServiceProxy : IJCDecauxServiceProxy
    {
        private static readonly HttpClient client = new HttpClient();
        private static DateTimeOffset defaultDateTimeOffset = ObjectCache.InfiniteAbsoluteExpiration;
        private static readonly string API_KEY = "4366cb72a2d1830a493e2cc4c6a3733a7a36583d";

        public List<JCDContract> getContractsList()
        {
            string url = "https://api.jcdecaux.com/vls/v3/contracts";
            string query = "";
            return Get<List<JCDContract>>(url + "?" + query);
        }

        public List<JCDStation> getStationsList()
        {
            string url = "https://api.jcdecaux.com/vls/v3/stations";
            string query = "";
            return Get<List<JCDStation>>(url + "?" + query);
        }

        public List<JCDStation> getStationsListWithContractName(string contractName)
        {
            string url = "https://api.jcdecaux.com/vls/v3/stations";
            string query = "contract=" + contractName;
            return Get<List<JCDStation>>(url + "?" + query);
        }

        private async Task<string> JCDecauxAPIGetCall(string urlAndQueries)
        {
            HttpResponseMessage response = await client.GetAsync(urlAndQueries + "&apiKey=" + API_KEY);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        
        public T Get<T>(string cacheItemName, DateTimeOffset dt)
        {
            ObjectCache cache = MemoryCache.Default;
            T response = (T) cache[cacheItemName];
            if (response == null)
            {
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = dt;
                response = JsonSerializer.Deserialize<T>(JCDecauxAPIGetCall(cacheItemName).Result);
                cache.Set(cacheItemName, response, policy);
            }
            return response;
        }

        public T Get<T>(string cacheItemName, double dt_seconds)
        {
            return Get<T>(cacheItemName, DateTimeOffset.Now.AddSeconds(dt_seconds));
        }

        public T Get<T>(string cacheItemName)
        {
            return Get<T>(cacheItemName, defaultDateTimeOffset);
        }
    }
}
