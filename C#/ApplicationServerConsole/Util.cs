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
        public static string ToStringDouble(double d)
        {
            return d.ToString(CultureInfo.InvariantCulture);
        }

        public static Itinerary calculateItinenary(List<OpenRouteDirection> oSMObjects)
        {
            oSMObjects.Select(o => o.metadata.query.profile);
            Itinerary itinerary = new Itinerary();
            Segment segment = new Segment();
            foreach (OpenRouteDirection obj in oSMObjects)
            {
                Segment seg = obj.features.First().properties.segments.First();
                string profile = obj.metadata.query.profile;
                itinerary.directions.Add(new Direction(seg, profile));
                itinerary.distance += obj.features.First().properties.summary.distance;
                itinerary.duration += obj.features.First().properties.summary.duration;
            }

            return itinerary;
        }

        public static GeoCoordinate convertPositionToGeoCoordinate(Position p)
        {
            return new GeoCoordinate(p.latitude, p.longitude);
        }
    }
}
