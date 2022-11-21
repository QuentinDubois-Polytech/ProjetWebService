﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ApplicationServer.JCDecauxServiceProxy;

namespace ApplicationServer
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IApplicationService
    {
        [OperationContract]
        // Méthode principale permettant de récupérer les directions entre deux points.
        Itinerary GetItinerary(Position origin, Position destination);
    }
}
