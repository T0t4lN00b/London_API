using System;
using API;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace API_Tests
{
    //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    //:: Testing coordinate calculations are accurate using GeoCalculator2 formula  ::       
    //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::


    [TestClass]
    public class Geo2_UnitTest
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

            var result = GeoCalculator2.Distance(LondonLat, LondonLong, mayfairLat, mayfairLong, 'M');

            Assert.AreEqual(1.6246282256479903, result);
        }

        //Testing distance from my house to another landmark
        [TestMethod]
        public void MyHouseIs3MilesToCivicHall_Test()
        {
            double nantwichLat = 53.0685587, nantwichLong = -2.522313;

            var result = GeoCalculator2.Distance(CreweLat, CreweLong, nantwichLat, nantwichLong, 'M');

            Assert.AreEqual(3.1524057094472675, result);
        }
    }
}
