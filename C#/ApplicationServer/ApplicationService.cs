using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ApplicationServer.JCDecauxServiceProxy;

namespace ApplicationServer
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
        public List<Itinerary> GetItinerary(string origin, string destination)
        {
            // need to convert the adresse of origin and distination in poistion with OpenStreetMap

            //JCDStation stationOrigin = ClientJCDecauxAPI.retrieveClosestStationDeparture(origin, "nom de la ville de départ");
            //JCDStation stationDestination = ClientJCDecauxAPI.retrieveClosestStationArrival(destination, "nom de la ville d'arivée");

            // need to convert the position of origin and distination in adresse with OpenStreetMap
            Position originLocation = clientOpenStreetMap.GetLocation(origin).Result;
            Position destinationLocation = clientOpenStreetMap.GetLocation(destination).Result;

            JCDStation stationOrigin = ClientJCDecauxAPI.retrieveClosestStationDeparture(originLocation);
            JCDStation stationDestination = ClientJCDecauxAPI.retrieveClosestStationArrival(originLocation);

            // need to calculate the itinerary with JCDecaux API
            Itinerary walk1 = clientOpenStreetMap.GetItinerary(originLocation, stationOrigin.position, false).Result;
            Itinerary bike = clientOpenStreetMap.GetItinerary(stationOrigin.position, stationDestination.position, true).Result;
            Itinerary walk2 = clientOpenStreetMap.GetItinerary(stationDestination.position, destinationLocation, false).Result;

            return new List<Itinerary> { walk1, bike, walk2 };

            // need to compute 3 itineraries one with the use of bike
            // the other just by walking from the origin to detsination
            // give the one with less time
        }
    }
}
