using System.Device.Location;

namespace API
{
    public class GeoCalculator
    {
        public static double GetDistanceTo(double Latitude, double Longitude, double otherLatitude,
            double otherLongitude)
        {
            var nGeoCoordinate = new GeoCoordinate(Latitude, Longitude);
            var eGeoCoordinate = new GeoCoordinate(otherLatitude, otherLongitude);

            return ConvertMetresToMiles(nGeoCoordinate.GetDistanceTo(eGeoCoordinate));
        }

        public static double ConvertMetresToMiles(double metres)
        {
            return (metres / 1609.344);
        }
    }
}

