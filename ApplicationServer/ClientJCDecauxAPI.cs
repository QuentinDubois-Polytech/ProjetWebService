﻿using System;
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
using ApplicationServer.JCDecauxServiceProxy;
using ApplicationServer.ContractTypes;

namespace ApplicationServer
{
    public class ClientJCDecauxAPI
    {
        private static readonly JCDecauxServiceProxyClient proxy = new JCDecauxServiceProxyClient();

        private static List<JCDContract> retrieveContracts()
        {
            string response = proxy.getContractsList();
            return JsonSerializer.Deserialize<List<JCDContract>>(response);
        }

        private static List<JCDStation> retrieveStations(string contractName)
        {
            string response = proxy.getStationsListWithContractName(contractName);
            return JsonSerializer.Deserialize<List<JCDStation>>(response);
        }

        public static List<JCDStation> retrieveStations()
        {
            string response = proxy.getStationsList();
            return JsonSerializer.Deserialize<List<JCDStation>>(response);
        }

        public static JCDStation retrieveClosestStation(Position position, List<JCDStation> stations)
        {
            GeoCoordinate chosenStationGeo = new GeoCoordinate(position.latitude, position.longitude);

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

        public static JCDStation retrieveClosestStationDeparture(Position position, List<JCDStation> stations)
        {
            return retrieveClosestStation(position, retrieveStations().Where<JCDStation>(station => station.totalStands.availabilities.bikes != 0).ToList());
        }

        public static JCDStation retrieveClosestStationArrival(Position position, List<JCDStation> stations)
        {
            return retrieveClosestStation(position, retrieveStations().Where<JCDStation>(station => station.totalStands.availabilities.stands != 0).ToList());
        }
    }
}

