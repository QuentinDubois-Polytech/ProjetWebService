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
        private List<JCDStation> stations;
        private ClientJCDecauxAPI clientJCDecaux;

        public ApplicationService()
        {
            clientJCDecaux = new ClientJCDecauxAPI();
        }
        public Itinerary GetItinerary(Position origin, Position destination)
        {
            // need to convert the adresse of origin and distination in poistion with OpenStreetMap
            JCDStation stationOrigin = ClientJCDecauxAPI.retrieveClosestStationDeparture(origin, "nom de la ville de départ");
            JCDStation stationDestination = ClientJCDecauxAPI.retrieveClosestStationArrival(destination, "nom de la ville d'arivée");

            // need to compute 3 itineraries one with the use of bike
            // the other just by walking from the origin to detsination
            // give the one with less time
            throw new NotImplementedException();
        }
    }
}
