using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using API;

namespace API_Tests

    //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    //:: Testing coordinate calculations are accurate using .Net Assembly  ::       
    //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
{
    [TestClass]
    public class Geo_UnitTest
    {
        //According to https://www.latlong.net/place/london-uk-14153.html these are the coordinates for London.
        private const double LondonLat = 51.509865, LondonLong = -0.118092;

        //Accoring to GoogleMaps these are the coordinates for my address
        private const double CreweLat = 53.0873453, CreweLong = -2.4530962;


        //Testing distance from Mayfair to the coordinates marked as London
        [TestMethod]
        public void LondonToMayfair_Test()
        {
            double mayfairLat = 51.5092459, mayfairLong = -0.1558605;

            var result = GeoCalculator.GetDistanceTo(LondonLat, LondonLong, mayfairLat, mayfairLong);

            Assert.AreEqual(1.6261089785322889, result);
        }

        //Testing distance from my house to another landmark
        [TestMethod]
        public void MyHouseIs3MilesFromCivicHall_Test()
        {
            double nantwichLat = 53.0685587, nantwichLong = -2.522313;

            var result = GeoCalculator.GetDistanceTo(CreweLat, CreweLong, nantwichLat, nantwichLong);

            Assert.AreEqual(3.1552789428815897, result);

        }

        //Testing distance from my house to St Peters Square 28.34 mi
        [TestMethod]
        public void MyHouse_ToWork_Test()
        {

            double StPeterLat = 53.4782907, StPeterLong = -2.2455521;

            var result = GeoCalculator.GetDistanceTo(CreweLat, CreweLong, StPeterLat, StPeterLong);

            Assert.AreEqual(28.364068969396072, result);
        }

        //Test to make sure that calculation of only 3 people are within 50 miles of London is correct
        [TestMethod]

        public void ThisUserIsWithinCoOrdinatesOfLondon_Test()
        {
            double LonLat = 49.6355347, LonLong = -1.6272462;

            var result = GeoCalculator.GetDistanceTo(LondonLat, LondonLong, LonLat, LonLong);

            Assert.AreEqual(50, result);
        }
            
            
    }
}
