using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ApplicationServer
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class ApplicationService : IApplicationService
    {
        private List<JCDStation> stations;

        public ApplicationService()
        {
            stations = ClientJCDecauxAPI.retrieveStations();
        }
        public Itinerary GetItinerary(Position origin, Position destination)
        {
            // need to convert the adresse of origin and distination in poistion with OpenStreetMap
            JCDStation stationOrigin = ClientJCDecauxAPI.retrieveClosestStation(origin, stations);
            JCDStation stationDestination = ClientJCDecauxAPI.retrieveClosestStation(destination, stations);

            // need to compute 3 itineraries one with the use of bike
            // the other just by walking from the origin to detsination
            // give the one with less time
            throw new NotImplementedException();
        }
    }
}
