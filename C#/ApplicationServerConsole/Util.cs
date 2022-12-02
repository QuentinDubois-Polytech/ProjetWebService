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
        public static Itinerary calculateItinenary(List<OpenRouteServiceDirections> oSMObjects)
        {
            oSMObjects.Select(o => o.metadata.query.profile);
            Itinerary itinerary = new Itinerary();
            Segment segment = new Segment();
            foreach (OpenRouteServiceDirections obj in oSMObjects)
            {
                Segment seg = obj.routes[0].segments[0];
                string profile = obj.metadata.query.profile;
                itinerary.directions.Add(new Direction(seg, profile));
                itinerary.distance += obj.routes[0].summary.distance;
                itinerary.duration += obj.routes[0].summary.duration;
            }

            return itinerary;
        }

        public static GeoCoordinate convertPositionToGeoCoordinate(Position p)
        {
            return new GeoCoordinate(p.latitude, p.longitude);
        }

        public static double calculateDuration(List<OpenRouteServiceDirections> openRouteDirections)
        {
            return openRouteDirections.Select(o => o.routes[0].summary.duration).Sum();
        }
    }
}
