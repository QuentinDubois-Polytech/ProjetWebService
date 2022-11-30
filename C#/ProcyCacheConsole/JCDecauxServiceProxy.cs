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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class JCDecauxServiceProxy : IJCDecauxServiceProxy
    {
        private readonly HttpClient client = new HttpClient();
        private static readonly string API_KEY = "4366cb72a2d1830a493e2cc4c6a3733a7a36583d";
        private static readonly double CACHE_DURATION = 5; //en minutes

        public JCDecauxServiceProxy()
        {
           
        }

        public List<JCDContract> getContractsList()
        {
            string url = "https://api.jcdecaux.com/vls/v3/contracts";
            string query = "";
            string response = getResponseFromCache(url, query);
            return JsonSerializer.Deserialize<List<JCDContract>>(response);
        }

        public List<JCDStation> getStationsList()
        {
            string url = "https://api.jcdecaux.com/vls/v3/stations";
            string query = "";
            string response = getResponseFromCache(url, query);
            return JsonSerializer.Deserialize<List<JCDStation>>(response);
        }

        public  List<JCDStation> getStationsListWithContractName(string contractName)
        {
            string url = "https://api.jcdecaux.com/vls/v3/stations";
            string query = "contract=" + contractName;
            string response = getResponseFromCache(url, query);
            return JsonSerializer.Deserialize<List<JCDStation>>(response);
        }

        private async Task<string> JCDecauxAPIGetCall(string url, string query)
        {
            HttpResponseMessage response = await client.GetAsync(url + "?" + query + "&apiKey=" + API_KEY);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private async Task<string> JCDecauxAPIPostCall(string url, HttpContent content)
        {
            HttpResponseMessage response = await client.PostAsync(url + "?" + "apiKey=" + API_KEY, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private string getResponseFromCache(string url, string query)
        {
            ObjectCache cache = MemoryCache.Default;
            string key = url + "?" + query;
            string response = cache[key] as string;

            if (response == null)
            {
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration =
                    DateTimeOffset.Now.AddMinutes(CACHE_DURATION);
                response = JCDecauxAPIGetCall(url, query).Result;
                cache.Set(key, response, policy);
                
            }
            return response;
        }
    }
}
