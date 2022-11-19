using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections;
using System.Security.Policy;
using System.Text.Json;
using System.Diagnostics.Contracts;
using System.Device.Location;

namespace ApplicationServer
{
    public class ClientJCDecauxAPI
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string API_KEY = "4366cb72a2d1830a493e2cc4c6a3733a7a36583d";

        public static List<JCDContract> retrieveContracts()
        {
            string url = "https://api.jcdecaux.com/vls/v3/contracts";
            string query = "";
            string response = JCDecauxAPIGetCall(url, query).Result;
            return JsonSerializer.Deserialize<List<JCDContract>>(response);
        }

        public static List<JCDStation> retrieveStations(string contractName)
        {
            string url = "https://api.jcdecaux.com/vls/v3/stations";
            string query = "contract=" + contractName;
            string response = JCDecauxAPIGetCall(url, query).Result;
            return JsonSerializer.Deserialize<List<JCDStation>>(response);
        }

        public static JCDStation retrieveClosestStation(JCDStation chosenStation)
        {
            GeoCoordinate chosenStationGeo = new GeoCoordinate(chosenStation.position.latitude, chosenStation.position.longitude);
            
            double minDistance = Double.MaxValue;
            JCDStation closestStation = chosenStation;
            
            foreach (JCDStation station in retrieveStations(chosenStation.contractName))
            {
                if (station != chosenStation)
                {
                    // Find the current station's position.
                    GeoCoordinate stationGeo = new GeoCoordinate(station.position.latitude, station.position.longitude);
                    // And compare its distance to the chosen one to see if it is closer than the current closest.
                    double distance = chosenStationGeo.GetDistanceTo(stationGeo);

                    if (distance < minDistance)
                    {
                        closestStation = station;
                        minDistance = distance;
                    }
                }
            }
            return closestStation;
        }
        
        private static async Task<string> JCDecauxAPIGetCall(string url, string query)
        {
            HttpResponseMessage response = await client.GetAsync(url + "?" + query + "&apiKey=" + API_KEY);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private static async Task<string> JCDecauxAPIPostCall(string url, HttpContent content)
        {
            HttpResponseMessage response = await client.PostAsync(url + "?" + "apiKey=" + API_KEY, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}

