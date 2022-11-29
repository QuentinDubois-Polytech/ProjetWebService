using ApplicationServerConsole.JCDecauxServiceProxy;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.Json;

namespace ApplicationServerConsole
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class ApplicationService : IApplicationService
    {
        private ClientJCDecauxAPI clientJCDecaux;
        private ClientOpenStreetMapAPI clientOpenStreetMap;

        public ApplicationService()
        {
            clientJCDecaux = new ClientJCDecauxAPI();
            clientOpenStreetMap = new ClientOpenStreetMapAPI();
        }
        public Itinerary GetItinerary(string origin, string destination)
        {
            GeoCoordinate originLocation = clientOpenStreetMap.GetLocation(origin).Result;
            GeoCoordinate destinationLocation = clientOpenStreetMap.GetLocation(destination).Result;

            ClientJCDecauxAPI clientJCDecaux = new ClientJCDecauxAPI();
            JCDStation stationOrigin = clientJCDecaux.retrieveClosestStationDeparture(originLocation);
            JCDStation stationDestination = clientJCDecaux.retrieveClosestStationArrival(originLocation);

            GeoCoordinate stationOriginLocation = Util.convertPositionToGeoCoordinate(stationOrigin.position);
            GeoCoordinate stationDestinationLocation = Util.convertPositionToGeoCoordinate(stationDestination.position);

            OpenRouteDirection walkOnly = clientOpenStreetMap.GetItineraryByBiking(originLocation, destinationLocation).Result;
            OpenRouteDirection walkOriginToStation = clientOpenStreetMap.GetItineraryByWalking(originLocation, stationOriginLocation).Result;

            if (walkOnly.getDuration() < walkOriginToStation.getDuration())
            {
                return Util.calculateItinenary(new List<OpenRouteDirection>() { walkOnly });
            }
            
            OpenRouteDirection bikeStationToStation = clientOpenStreetMap.GetItineraryByBiking(stationOriginLocation, stationDestinationLocation).Result;
            if (walkOnly.getDuration() < Util.calculateDuration(new List<OpenRouteDirection> { walkOriginToStation, bikeStationToStation }))
            {
                return Util.calculateItinenary(new List<OpenRouteDirection>() { walkOnly });
            }

            OpenRouteDirection walkStationToDestination = clientOpenStreetMap.GetItineraryByWalking(stationDestinationLocation, destinationLocation).Result;
            if (walkOnly.getDuration() < Util.calculateDuration(new List<OpenRouteDirection> { walkOriginToStation, bikeStationToStation, walkStationToDestination }))
            {
                return Util.calculateItinenary(new List<OpenRouteDirection>() { walkOnly });
            }
            
            return Util.calculateItinenary(new List<OpenRouteDirection> { walkOriginToStation, bikeStationToStation, walkStationToDestination});
        }
    }
}
