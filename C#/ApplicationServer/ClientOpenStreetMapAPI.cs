﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using ApplicationServer.JCDecauxServiceProxy;
using System.Runtime.ConstrainedExecution;

namespace ApplicationServer
{
    public class ClientOpenStreetMapAPI
    {
        private readonly HttpClient client;
        private static readonly string API_KEY = "5b3ce3597851110001cf6248533c8f297d74424baa814af18ec650eb";

        public ClientOpenStreetMapAPI()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "BikeApplication");
        }

        public async Task<Position> GetLocation(string address)
        {
            string url = "https://nominatim.openstreetmap.org/search/" + address;
            string query = "format=json&addressdetails=1&limit=1&polygon_svg=1";
            HttpResponseMessage response = await client.GetAsync(url + "?" + query);
            response.EnsureSuccessStatusCode();
            string responseData = await response.Content.ReadAsStringAsync();
            OSMObject osmObject = JsonSerializer.Deserialize<List<OSMObject>>(responseData).First();
            return osmObject.GetPosition();

        }

        public async Task<Itinerary> GetItinerary(string start, string end, Boolean bicycle)
        {
            Task<Position> startingPosition = GetLocation(start);
            Task<Position> endPosition = GetLocation(end);
            startingPosition.Wait();
            endPosition.Wait();
            return await GetItinerary(start, end, bicycle);
        }


        public async Task<Itinerary> GetItinerary(Position start, Position end, Boolean bicycle)
        {
            // OpenRouteService inverse l'ordre habituelle de la représentation d'une coordonnée (latitude, longitude)
            // A la place il utilise (longitude, latitude)
            // (bicycle ? "cycling-regular" : "foot-walking")
            string url = "https://api.openrouteservice.org/v2/directions/" + "driving-car" + "?api_key=" + API_KEY;
            string query = "&start=" + start.longitude + "," + start.latitude + "&end=" +end.longitude + "," + end.latitude; //"&size=1"
            HttpResponseMessage response = await client.GetAsync(url + query);
            response.EnsureSuccessStatusCode();
            string responseData = await response.Content.ReadAsStringAsync();
            
            OpenRouteDirection openRouteDirection = JsonSerializer.Deserialize<OpenRouteDirection>(responseData);
            return new Itinerary(openRouteDirection.features.First().properties.segments[0].steps.ToList());


        }
    }
}

