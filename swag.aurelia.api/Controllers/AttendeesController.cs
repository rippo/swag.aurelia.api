using System.Collections.Generic;
using System.Web.Http;
using swag.aurelia.api.Infrastructure;
using swag.aurelia.api.Models;

namespace swag.aurelia.api.Controllers
{

    //TO TEST
    //  curl -H "Accept: application/json" "http://localhost:55376/api/attendees"
    //copy output and paste into
    //http://json.parser.online.fr/

    public class AttendeesController : ApiController
    {
        // GET api/attendees
        public IEnumerable<Attendee> Get()
        {
            return new Meetup().LoadFromMeetup();
        }

    }
}
