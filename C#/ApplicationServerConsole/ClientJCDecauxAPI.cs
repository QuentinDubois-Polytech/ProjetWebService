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
using ApplicationServerConsole.JCDecauxServiceProxy;

namespace ApplicationServerConsole
{
    public class ClientJCDecauxAPI
    {
        private static readonly JCDecauxServiceProxyClient proxy = new JCDecauxServiceProxyClient();
        private readonly HttpClient client = new HttpClient();
        private static readonly string API_KEY = "4366cb72a2d1830a493e2cc4c6a3733a7a36583d";


        public JCDStation retrieveClosestStation(GeoCoordinate chosenStationGeo, List<JCDStation> stations)
        {

            double minDistance = Double.MaxValue;
            JCDStation closestStation = null;

            foreach (JCDStation station in stations)
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
            return closestStation;
        }

        public JCDStation retrieveClosestStationDeparture(GeoCoordinate position)
        {
            return retrieveClosestStation(position, getStationsList().Where<JCDStation>(station => station.totalStands.availabilities.bikes != 0).ToList());
        }

        public JCDStation retrieveClosestStationArrival(GeoCoordinate position)
        {
            return retrieveClosestStation(position, getStationsList().Where<JCDStation>(station => station.totalStands.availabilities.stands != 0).ToList());
        }

        public List<JCDStation> getStationsList()
        {
            string url = "https://api.jcdecaux.com/vls/v3/stations";
            string query = "";
            string response = JCDecauxAPIGetCall(url, query).Result;
            //Console.WriteLine(response);
            return JsonSerializer.Deserialize<List<JCDStation>>(response);
        }

        private async Task<string> JCDecauxAPIGetCall(string url, string query)
        {
            HttpResponseMessage response = await client.GetAsync(url + "?" + query + "&apiKey=" + API_KEY);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}

