using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ApplicationServer
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IApplicationService
    {
        [OperationContract]
        // Méthode principale permettant de récupérer les directions entre deux points.
        List<Itinerary> getDirections(Position depart, Position arrival);
    }
}
