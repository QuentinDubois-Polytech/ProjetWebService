using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using ApplicationServerConsole.JCDecauxServiceProxy;
using System.Runtime.ConstrainedExecution;
using System.Globalization;
using System.Device.Location;

namespace ApplicationServerConsole
{
    public class ClientOpenStreetMapAPI
    {
        private readonly HttpClient client;
        private static readonly string Biking = "cycling-regular/";
        private static readonly string Walking = "foot-walking/";
        private static readonly string API_KEY = "5b3ce3597851110001cf6248533c8f297d74424baa814af18ec650eb";

        public ClientOpenStreetMapAPI()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "MyBikeApplication");
        }

        public async Task<GeoCoordinate> GetLocation(string address)
        {
            string url = "https://nominatim.openstreetmap.org/search/" + address;
            string query = "format=json&addressdetails=1&limit=1&polygon_svg=1";
            HttpResponseMessage response = await client.GetAsync(url + "?" + query);
            response.EnsureSuccessStatusCode();
            string responseData = await response.Content.ReadAsStringAsync();
            OSMObject osmObject = JsonSerializer.Deserialize<List<OSMObject>>(responseData).First();
            return osmObject.GetGeoCoordinate();

        }

        public async Task<OpenRouteDirection> GetItineraryByWalking(GeoCoordinate start, GeoCoordinate end) {
            return await GetItinerary(start, end, ClientOpenStreetMapAPI.Walking);
        }

        public async Task<OpenRouteDirection> GetItineraryByBiking(GeoCoordinate start, GeoCoordinate end)
        {
            return await GetItinerary(start, end, ClientOpenStreetMapAPI.Biking);
        }


        public async Task<OpenRouteDirection> GetItinerary(GeoCoordinate start, GeoCoordinate end, string profile)
        {
            // OpenRouteService inverse l'ordre habituelle de la représentation d'une coordonnée (latitude, longitude)
            // A la place il utilise (longitude, latitude)
            // (bicycle ? "cycling-regular" : "foot-walking")
            //Console.WriteLine(JsonSerializer.Serialize(start));
            //Console.WriteLine(JsonSerializer.Serialize(end));
            string url = "https://api.openrouteservice.org/v2/directions/" + profile + "?api_key=" + API_KEY;
            string query = "&start=" + Util.ToStringDouble(start.Longitude) + "," + Util.ToStringDouble(start.Latitude) + 
                "&end=" + Util.ToStringDouble(end.Longitude) + "," + Util.ToStringDouble(end.Latitude) + "&size=1";
            //Console.WriteLine($"Api call to OpenRouteService {url + query}");
            //Console.ReadLine();
            HttpResponseMessage response = await client.GetAsync(url + query);
            response.EnsureSuccessStatusCode();
            string responseData = await response.Content.ReadAsStringAsync();
            //Console.ReadLine();
            OpenRouteDirection openRouteDirection = JsonSerializer.Deserialize<OpenRouteDirection>(responseData);
            return openRouteDirection;


        }
    }
}

