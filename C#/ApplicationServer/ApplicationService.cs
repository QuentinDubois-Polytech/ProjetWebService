using ApplicationServerConsole.JCDecauxServiceProxy;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Net.Http;

namespace ApplicationServer
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class ApplicationService : IApplicationService
    {

        public Itinerary GetItinerary(string origin, string destination)
        {

            OpenRouteServiceSearch originSearch = null;
            try
            {

                originSearch = ClientOpenStreetMapAPI.GetCoordonates(origin).Result;
            }
            catch (LocationNotFound e)
            {
                // Impossible to find the coordinates of the departure point
                return new Itinerary(e);
            }

            GeoCoordinate originLocation = originSearch.GetGeoCoordinate();

            OpenRouteServiceSearch destinationSearch = null;
            try
            {
                destinationSearch = ClientOpenStreetMapAPI.GetCoordonates(destination).Result;
            }
            catch (LocationNotFound e)
            {
                // Impossible to find the coordinates of the arrival point
                return new Itinerary(e);
            }
            
            GeoCoordinate destinationLocation = destinationSearch.GetGeoCoordinate();

            JCDStation[] stations = null;
            try
            {
                stations = ClientJCDecauxAPI.retrieveStations(originSearch, destinationSearch);
            }
            catch (Exception e) when (e is JCDContractNotFoundException || e is JCDContractsOfArrivalAndDepartureAreDifferents || e is JCDStationNotFound)
            {
                // JCDContractNotFoundException : No contract found in the departure or arrival cities
                // JCDContractsOfArrivalAndDepartureAreDifferents : The cities are in differents contracts
                // JCDStationNotFound : No station found in the contracts corresponding to the conditions
                Itinerary res;
                try
                {
                    res = new Itinerary(ClientOpenStreetMapAPI.GetItineraryByWalking(originLocation, destinationLocation).Result, ClientOpenStreetMapAPI.Walking);
                } catch (AggregateException)
                {
                    return new Itinerary(new ItineraryNotFound(origin, destination));
                }
                res.isException = true;
                res.exception = e.Message;
                return res;
            }

            JCDStation stationOrigin = stations[0];
            JCDStation stationDestination = stations[1];

            GeoCoordinate stationOriginLocation = Util.convertPositionToGeoCoordinate(stationOrigin.position);
            GeoCoordinate stationDestinationLocation = Util.convertPositionToGeoCoordinate(stationDestination.position);

            OpenRouteServiceDirection walkOnly = ClientOpenStreetMapAPI.GetItineraryByWalking(originLocation, destinationLocation).Result;
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
