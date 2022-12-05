using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServerConsole
{
    public class JCDContractNotFoundException: Exception
    {
        public JCDContractNotFoundException(string cityName) : base("No contract was found for city: " + cityName)
        {
        }
    }

    public class JCDStationNotFound : Exception
    {
        public JCDStationNotFound() : base("No station was found for station")
        {
        }
    }

    public class JCDContractsOfArrivalAndDepartureAreDifferents: Exception
    {
        public JCDContractsOfArrivalAndDepartureAreDifferents(string ContractNameDeparture, string ContractNameArrival) : base("The departure contract: " + ContractNameDeparture + " is different of the arrival contract: " + ContractNameArrival) { }
    }
}
