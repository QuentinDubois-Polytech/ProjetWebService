using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProxyCacheConsole
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IJCDecauxServiceProxy
    {
        [OperationContract]
        List<JCDContract> getContractsList();

        [OperationContract]
        List<JCDStation> getStationsList();

        [OperationContract]
        List<JCDStation> getStationsListWithContractName(string contractName);

    }
}
