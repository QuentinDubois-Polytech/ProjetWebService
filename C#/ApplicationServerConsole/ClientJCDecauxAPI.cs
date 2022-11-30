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
using System.ServiceModel;

namespace ApplicationServerConsole
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

        public static JCDStation retrieveClosestStation(GeoCoordinate chosenStationGeo, List<JCDStation> stations)
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
        
        public static JCDStation retrieveClosestStationDeparture(GeoCoordinate position)
        {
            return retrieveClosestStation(position, proxy.getStationsList().Where(station => station.totalStands.availabilities.bikes != 0).ToList());
        }

        public static JCDStation retrieveClosestStationArrival(GeoCoordinate position)
        {
            return retrieveClosestStation(position, proxy.getStationsList().Where(station => station.totalStands.availabilities.stands != 0).ToList());
        }
    }
}

