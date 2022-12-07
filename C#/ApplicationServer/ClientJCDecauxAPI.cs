using System;
using System.Collections.Generic;
using System.Linq;
using System.Device.Location;
using ApplicationServerConsole.JCDecauxServiceProxy;
using System.ServiceModel;

namespace ApplicationServer
{
    public class ClientJCDecauxAPI
    {
        private static readonly JCDecauxServiceProxyClient proxy;

        static ClientJCDecauxAPI()
        {
            BasicHttpBinding basicHttpBinding = new BasicHttpBinding();
            basicHttpBinding.MaxReceivedMessageSize = 2097152;

            EndpointAddress jCDProxyEndpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/ProxyCache/JCDecauxServiceProxy/");
            proxy = new JCDecauxServiceProxyClient(basicHttpBinding, jCDProxyEndpoint);
        }
        
        public static JCDStation retrieveClosestStation(GeoCoordinate chosenStationGeo, IEnumerable<JCDStation> stations)
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
        
        public static JCDStation retrieveClosestStationDeparture(GeoCoordinate position, JCDStation[] stations)
        {
            return retrieveClosestStation(position, stations.Where(station => station.totalStands.availabilities.bikes != 0));
        }

        public static JCDStation retrieveClosestStationArrival(GeoCoordinate position, JCDStation[] stations)
        {
            return retrieveClosestStation(position, stations.Where(station => station.totalStands.availabilities.stands != 0));
        }

        public static string getContractName(string city)
        {
            city = city.Substring(0,1).ToUpper() + city.Substring(1).ToLower();
            JCDContract[] contracts = proxy.getContractsList();

            foreach (JCDContract contract in contracts)
            {
                if (contract.cities != null && contract.cities.Contains(city))
                {
                    return contract.name;
                }
            }

            return null;
        }

        public static JCDStation[] retrieveStations(OpenRouteServiceSearch origin, OpenRouteServiceSearch destination)
        {
            string contractNameDeparture = getContractName(origin.GetCity());
            if (contractNameDeparture == null)
                throw new JCDContractNotFoundException(origin.GetCity());

            string contractNameArrival = getContractName(destination.GetCity());
            if (contractNameDeparture == null)
                throw new JCDContractNotFoundException(destination.GetCity());

            if (! contractNameDeparture.Equals(contractNameArrival))
            {
                throw new JCDContractsOfArrivalAndDepartureAreDifferents(contractNameDeparture, contractNameArrival);
            }

            JCDStation[] stations = proxy.getStationsListWithContractName(contractNameDeparture);
            JCDStation departureStation = retrieveClosestStationDeparture(origin.GetGeoCoordinate(), stations);

            if (departureStation == null)
            {
                throw new JCDStationNotFound(origin.GetCity(), JCDStationNotFound.DEPARTURE);
            }
            
            JCDStation arrivalStation = retrieveClosestStationArrival(destination.GetGeoCoordinate(), stations);

            if (arrivalStation == null)
            {
                throw new JCDStationNotFound(destination.GetCity(), JCDStationNotFound.ARRIVAL);
            }
            
            return new JCDStation[] { departureStation, arrivalStation };
        }
    }
}

