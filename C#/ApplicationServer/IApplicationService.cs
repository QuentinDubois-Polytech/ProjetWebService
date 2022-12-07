using System.ServiceModel;

namespace ApplicationServer
{
    [ServiceContract]
    public interface IApplicationService
    {
        [OperationContract]
        Itinerary GetItinerary(string origin, string destination);
    }
}
