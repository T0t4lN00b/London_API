using Newtonsoft.Json;
using API.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;


namespace API.Controllers
{
    public class UserController : ApiController
    {
        //According to https://www.latlong.net/place/london-uk-14153.html these are the coordinates for London.
        private const double londonLat = 51.509865, londonLong = -0.118092;

        //Return all users that are within 50 miles of London by entering mileage into URL by calling controller for example
        //https://bpdts-test-app.herokuapp.com/users/50

        public IHttpActionResult GetAllUsersWithin50Miles(double distance)
        {
            var client = new WebClient();
            var content = client.DownloadString("https://bpdts-test-app.herokuapp.com/users");

            var list = JsonConvert.DeserializeObject<List<Users>>(content);
            var outputList = new List<Users>();

            foreach (var users in list)
            {
                //check to see if this user is within 50 miles of London
                if (IsUserWithinSpecifiedDistanceOfLondon(users, distance))
                {
                    //add to output list
                    outputList.Add(users);
                }
            }

            if (outputList.Count < 1)
            {
                return NotFound();
            }

            return Ok(JsonConvert.SerializeObject(outputList));
        }


        //Calculation for if the user is within 50 miles of London
        private bool IsUserWithinSpecifiedDistanceOfLondon(Users user, double distanceToCheck)
        {
            var distance = GeoCalculator.GetDistanceTo(londonLat, londonLong, user.Latitude, user.Longitude);
            if (distance <= distanceToCheck)
            {
                return true;
            }
            return false;
        }
    }
}

