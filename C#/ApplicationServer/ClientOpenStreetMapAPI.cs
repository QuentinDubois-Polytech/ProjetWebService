using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServer
{
    internal class ClientOpenStreetMapAPI
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string API_KEY = "5b3ce3597851110001cf6248533c8f297d74424baa814af18ec650eb";

        public async Task<Location[]> getLocation(string address)
        {
            string url = "https://nominatim.openstreetmap.org/?";
            string text = "&addressdetails=1" + "&q=" + address + "&format=json" + "&limit=1";
            var baseAddress = new Uri(url + text);

            
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.TryAddWithoutValidation("accept", "*/*");
            client.DefaultRequestHeaders.TryAddWithoutValidation("accept-Encoding", "gzip, deflate, br");
            client.DefaultRequestHeaders.TryAddWithoutValidation("connection", "keep-alive");
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "PostmanRuntime/7.29.0");
            var response = await client.GetAsync(baseAddress);
            string responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Location[]>(responseData);
        }


        public async Task<Itinerary> getItinary(string start, string end, Boolean bicycle)
        {
            Task<Location[]> startingPosition = getLocation(start);
            Task<Location[]> endPosition = getLocation(end);
            startingPosition.Wait();
            endPosition.Wait();
            string url = "https://api.openrouteservice.org/v2/directions/" + (bicycle ? "cycling-regular" : "foot-walking") + "?api_key=";
            string text = "&start=" + startingPosition.Result[0].lon + "," + startingPosition.Result[0].lat + "&end=" +
                endPosition.Result[0].lon + "," + endPosition.Result[0].lat + "&size=1";
            var baseAddress = new Uri(url + API_KEY + text);

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json, application/geo+json, application/gpx+xml, img/png; charset=utf-8");

                using (var response = await httpClient.GetAsync(""))
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Itinerary>(responseData);
                }
            }
        }
    }
}

