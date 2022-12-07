using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServer
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

        [DataMember]
        public List<float[]> coordinates { get; set; }

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

        public Itinerary(Exception exception)
        {
            isException = true;
            this.exception = exception.Message;
        }

        public Itinerary(List<float[]> coordinates)
        {
            this.coordinates = coordinates;
        }

        public Itinerary()
        {
            isException = false;
            directions = new List<Direction>();
            coordinates = new List<float[]>();
        }

        public Itinerary(OpenRouteServiceDirection openRouteServiceDirection, string profile)
        {
            isException = false;
            directions = new List<Direction>();
            foreach (Segment seg in openRouteServiceDirection.features[0].properties.segments)
            {
                directions.Add(new Direction(seg, profile));
            }

            coordinates = new List<float[]>();
            for (int i = 0; i < openRouteServiceDirection.features[0].geometry.coordinates.Length; i++)
            {
                float[] coord = openRouteServiceDirection.features[0].geometry.coordinates[i];
                coordinates.Add(coord);
            }

            distance = openRouteServiceDirection.getDistance();
            duration = openRouteServiceDirection.getDuration();
        }

    }
}
