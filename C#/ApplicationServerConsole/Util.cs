using ApplicationServerConsole.JCDecauxServiceProxy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Device.Location;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServerConsole
{
    public class Util
    {
        public static Itinerary calculateItinenary(List<OpenRouteServiceDirection> oSMObjects)
        {
            oSMObjects.Select(o => o.metadata.query.profile);
            Itinerary itinerary = new Itinerary();
            Segment segment = new Segment();
            foreach (OpenRouteServiceDirection obj in oSMObjects)
            {
                Segment seg = obj.features[0].properties.segments[0];
                string profile = obj.metadata.query.profile;
                itinerary.directions.Add(new Direction(seg, profile));
                itinerary.distance += obj.features[0].properties.segments[0].distance;
                itinerary.duration += obj.features[0].properties.segments[0].duration;
                foreach(float[] coord in obj.features[0].geometry.coordinates)
                {
                    itinerary.coordinates.Add(coord);
                }
            }

            return itinerary;
        }

        public static GeoCoordinate convertPositionToGeoCoordinate(Position p)
        {
            return new GeoCoordinate(p.latitude, p.longitude);
        }

        public static double calculateDuration(List<OpenRouteServiceDirection> openRouteDirections)
        {
            return openRouteDirections.Select(o => o.features[0].properties.summary.duration).Sum();
        }
    }
}
