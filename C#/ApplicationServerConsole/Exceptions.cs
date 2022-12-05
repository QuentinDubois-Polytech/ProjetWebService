using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServerConsole
{
    public class JCDContractNotFoundException: Exception
    {
        public JCDContractNotFoundException(string cityName) : base("No contract was found for city: " + cityName)
        {
        }

        public string getMessage()
        {
            return Message;
        }
    }

    public class JCDStationNotFound : Exception
    {
        public static readonly string DEPARTURE = "Departure";
        public static readonly string ARRIVAL = "Arrival";
        public JCDStationNotFound(string contractName, string stationLocation) : base("No station was found in the contract name: " + contractName + " for " + stationLocation)
        {
            
        }
    }

    public class JCDContractsOfArrivalAndDepartureAreDifferents: Exception
    {
        public JCDContractsOfArrivalAndDepartureAreDifferents(string ContractNameDeparture, string ContractNameArrival) : base("The departure contract: " + ContractNameDeparture + " is different of the arrival contract: " + ContractNameArrival) { }
    }

    public class LocationNotFound : Exception
    {
        public LocationNotFound(string location) : base("The location: " + location + " was not found") { }
    }
}
