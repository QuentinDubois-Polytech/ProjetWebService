using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServerConsole
{
    [DataContract]
    public class Direction
    {
        public Direction(Segment segment, string profile)
        {
            this.segment = segment;
            this.profile = profile;
        }
        [DataMember]
        public Segment segment { get; set; }
        [DataMember]
        public string profile { get; set; }
    }

    [DataContract]
    public class Itinerary
    {
        public Itinerary()
        {
            isException = false;
            directions = new List<Direction>();
            coordinates = new List<float[]>();
        }

        [DataMember]
        public List<float[]> coordinates { get; set; }
        
        public Itinerary(Exception exception)
        {
            isException = true;
            this.exception = exception.Message;
        }

        public Itinerary(List<float[]> coordinates)
        {
            this.coordinates = coordinates;
        }

        [DataMember]
        public List<Direction> directions { get; set; }

        [DataMember]
        public double distance { get; set; }

        [DataMember]
        public double duration { get; set; }

        [DataMember]
        public bool isException { get; set; }

        [DataMember]
        public string exception { get; set; }

    }
}
