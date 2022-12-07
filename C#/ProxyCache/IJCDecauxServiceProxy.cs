using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProxyCacheConsole
{
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
