using System.Net;
using System.Web.Http;

namespace API.Controllers
{
    public class LondonController : ApiController
    {
        //Return all users that are listed as living in London
        public IHttpActionResult GetLondonUsers()
        {
            var client = new WebClient();
            var content = client.DownloadString("https://bpdts-test-app.herokuapp.com/city/London/users");

            if (content == null)
            {
                return NotFound();
            }

            return Ok(content);
        }
    }
}
