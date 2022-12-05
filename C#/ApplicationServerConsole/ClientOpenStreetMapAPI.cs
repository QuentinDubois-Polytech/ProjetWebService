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
using System.Net.Http.Headers;

namespace ApplicationServerConsole
{
    public class ClientOpenStreetMapAPI
    {
        private static readonly HttpClient client;
        private static readonly string Biking = "cycling-regular/";
        private static readonly string Walking = "foot-walking/";
        private static readonly string API_KEY = "5b3ce3597851110001cf6248533c8f297d74424baa814af18ec650eb";
        private static readonly string API_URL = "https://api.openrouteservice.org/";
        private static string DefaultLanguage = "fr";

        static ClientOpenStreetMapAPI()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("MyBikeApplication", "1.0"));
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue(DefaultLanguage));
        }

        // Using the Nominatim API (not used anymore)
        public static async Task<GeoCoordinate> GetLocation(string address)
        {
            string url = "https://nominatim.openstreetmap.org/search/" + address;
            string query = "format=json&addressdetails=1&limit=1&polygon_svg=1";
            HttpResponseMessage response = await client.GetAsync(url + "?" + query);
            response.EnsureSuccessStatusCode();
            string responseData = await response.Content.ReadAsStringAsync();
            OSMObject osmObject = JsonSerializer.Deserialize<List<OSMObject>>(responseData).First();
            return osmObject.GetGeoCoordinate();

        }

        // Using the OpenRouteService API
        public static async Task<OpenRouteServiceSearch> GetCoordonates(string address)
        {
            string url = API_URL + "geocode/search/";
            string query = "&text=" + address + "&size=1";
            string responseData = await APIGetCall(url, query);
            return JsonSerializer.Deserialize<OpenRouteServiceSearch>(responseData);
        }

        public static async Task<OpenRouteServiceDirection> GetItineraryByWalking(GeoCoordinate start, GeoCoordinate end) {
            return await GetItinerary(start, end, ClientOpenStreetMapAPI.Walking);
        }

        public static async Task<OpenRouteServiceDirection> GetItineraryByBiking(GeoCoordinate start, GeoCoordinate end)
        {
            return await GetItinerary(start, end, ClientOpenStreetMapAPI.Biking);
        }

        public static async Task<OpenRouteServiceDirection> GetItinerary(GeoCoordinate start, GeoCoordinate end, string profile)
        {
            // OpenRouteService inverse l'ordre habituelle de la représentation d'une coordonnée (latitude, longitude)
            string url = API_URL + "v2/directions/" + profile;
            string query = "&start=" + start.Longitude.ToString(CultureInfo.InvariantCulture) + "," + start.Latitude.ToString(CultureInfo.InvariantCulture) +
                "&end=" + end.Longitude.ToString(CultureInfo.InvariantCulture) + "," + end.Latitude.ToString(CultureInfo.InvariantCulture) + "&size=1";
            string responseData = await APIGetCall(url, query);
            return JsonSerializer.Deserialize<OpenRouteServiceDirection>(responseData);
        }

        private static async Task<string> APIPostCall(string url, string content)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(url));
            request.Headers.Authorization = new AuthenticationHeaderValue(API_KEY);
            request.Content = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        
        private static async Task<string> APIGetCall(string url, string query)
        {
            HttpResponseMessage response = await client.GetAsync(new Uri(url + "?" + query + "&api_key=" + API_KEY));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}

