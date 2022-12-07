using System;

namespace ApplicationServer
{
    public class JCDContractNotFoundException: Exception
    {
        public JCDContractNotFoundException(string cityName) : base("No contract was found for the city " + cityName)
        {
        }
    }

    public class JCDStationNotFound : Exception
    {
        public static readonly string DEPARTURE = "Departure";
        public static readonly string ARRIVAL = "Arrival";
        public JCDStationNotFound(string contractName, string stationLocation) : base("No station was found in the contract name " + contractName + " for " + stationLocation)
        {
            
        }
    }

    public class JCDContractsOfArrivalAndDepartureAreDifferents: Exception
    {
        public JCDContractsOfArrivalAndDepartureAreDifferents(string ContractNameDeparture, string ContractNameArrival) : base("The departure contract " + ContractNameDeparture + " is different of the arrival contract " + ContractNameArrival) { }
    }

    public class LocationNotFound : Exception
    {
        public LocationNotFound(string location) : base("The location: " + location + " was not found") { }
    }

    public class ItineraryNotFound : Exception
    {

        public ItineraryNotFound(string departure, string arrival) : base("No itinerary was found between " + departure + " and " + arrival) { }
    }
}
