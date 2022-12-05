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

        public Itinerary GetItinerary(string origin, string destination)
        {

            Console.WriteLine("1");
            OpenRouteServiceSearch originSearch = null;
            try
            {
                originSearch = ClientOpenStreetMapAPI.GetCoordonates(origin).Result;
            }
            catch (LocationNotFound e)
            {
                return new Itinerary(e);
            }

            Console.WriteLine("2");
            GeoCoordinate originLocation = originSearch.GetCoordinate();
            string city = originSearch.GetCity();

            Console.WriteLine("3");
            OpenRouteServiceSearch destinationSearch = null;
            try
            {
                destinationSearch = ClientOpenStreetMapAPI.GetCoordonates(destination).Result;
            }
            catch (LocationNotFound e)
            {
                return new Itinerary(e);
            }

            Console.WriteLine("4");
            GeoCoordinate destinationLocation = destinationSearch.GetCoordinate();

            Console.WriteLine("5");
            JCDStation[] stations = null;
            try
            {
                stations = ClientJCDecauxAPI.retrieveStations(originSearch, destinationSearch);
            }
            catch (JCDContractNotFoundException e)
            {
                Console.WriteLine("ici1");
                return new Itinerary(e);
            }
            catch (JCDContractsOfArrivalAndDepartureAreDifferents e)
            {
                Console.WriteLine("ici2");
                return new Itinerary(e);
            }
            catch (JCDStationNotFound e)
            {
                Console.WriteLine("ici3");
                return new Itinerary(e);
            }

            Console.WriteLine("6");
            JCDStation stationOrigin = stations[0];
            JCDStation stationDestination = stations[1];

            GeoCoordinate stationOriginLocation = Util.convertPositionToGeoCoordinate(stationOrigin.position);
            GeoCoordinate stationDestinationLocation = Util.convertPositionToGeoCoordinate(stationDestination.position);

            OpenRouteServiceDirection walkOnly = ClientOpenStreetMapAPI.GetItineraryByBiking(originLocation, destinationLocation).Result;
            OpenRouteServiceDirection walkOriginToStation = ClientOpenStreetMapAPI.GetItineraryByWalking(originLocation, stationOriginLocation).Result;

            if (walkOnly.getDuration() < walkOriginToStation.getDuration())
            {
                return Util.calculateItinenary(new List<OpenRouteServiceDirection>() { walkOnly });
            }
            
            OpenRouteServiceDirection bikeStationToStation = ClientOpenStreetMapAPI.GetItineraryByBiking(stationOriginLocation, stationDestinationLocation).Result;
            if (walkOnly.getDuration() < Util.calculateDuration(new List<OpenRouteServiceDirection> { walkOriginToStation, bikeStationToStation }))
            {
                return Util.calculateItinenary(new List<OpenRouteServiceDirection>() { walkOnly });
            }

            OpenRouteServiceDirection walkStationToDestination = ClientOpenStreetMapAPI.GetItineraryByWalking(stationDestinationLocation, destinationLocation).Result;
            if (walkOnly.getDuration() < Util.calculateDuration(new List<OpenRouteServiceDirection> { walkOriginToStation, bikeStationToStation, walkStationToDestination }))
            {
                return Util.calculateItinenary(new List<OpenRouteServiceDirection>() { walkOnly });
            }
            
            return Util.calculateItinenary(new List<OpenRouteServiceDirection> { walkOriginToStation, bikeStationToStation, walkStationToDestination});
        }
    }
}
