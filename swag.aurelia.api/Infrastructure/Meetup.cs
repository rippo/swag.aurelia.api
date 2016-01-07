using System.Collections.Generic;
using System.Linq;
using RestSharp;
using swag.aurelia.api.Models;

namespace swag.aurelia.api.Infrastructure
{
    public class Meetup
    {
        public List<Attendee> LoadFromMeetup()
        {
            return new InMemoryCache().Get("Meetup.Attendees", () =>
            {
                var api = new MeetupApiCall(ApplicationSettings.MeetupApiKey);

                //Get upcoming events
                var request = new RestRequest { Resource = ApplicationSettings.MeetupEventsUrl };
                request.AddUrlSegment("groupname", ApplicationSettings.MeetupGroupName);

                var events = api.Execute<EventDto>(request);
                var nextEvent = events.Results.First();

                //Get RSVP list from first event
                request = new RestRequest { Resource = ApplicationSettings.MeetupRsvpUrl };
                request.AddUrlSegment("eventid", nextEvent.Id);
                var rsvpList = api.Execute<RsvpDto>(request);

                //Do we have any guests?
                var guestCount = nextEvent.YesRsvpCount - rsvpList.Results.Count;

                //exclude coordinators
                var results = rsvpList.Results;
                //    .Where(w => !Settings.AttendeesExcludeList.Contains(w.Member.Name))
                //    .ToList();

                //BuildMemberModel(results, guestCount);

                return results;
            });
        }


        //private void BuildMemberModel(IEnumerable<Attendee> results, int guestCount)
        //{

        //    //lets fill the attendee and swag lists
        //    foreach (var result in results)
        //    {
        //        ApplicationData.Attendees.Add(
        //            new Attendee
        //            {
        //                Name = result.Member.Name.FirstNameAndSurnameInitial(),
        //                Photo = result.MemberPhoto != null
        //                    ? result.MemberPhoto.PhotoLink
        //                    : "http://img2.meetupstatic.com/2982428616572973604/img/noPhoto_80.gif",
        //                WonSwag = false,
        //                SwagThing = "?",
        //                MemberId = result.Member.MemberId
        //            });
        //    }

        //    for (var i = 1; i <= guestCount; i++)
        //    {
        //        ApplicationData.Attendees.Add(
        //            new Attendee
        //            {
        //                Name = "Guest " + i,
        //                Photo = "http://img2.meetupstatic.com/2982428616572973604/img/noPhoto_80.gif",
        //                WonSwag = false,
        //                SwagThing = "?",
        //                MemberId = -i
        //            });

        //    }

        //    ApplicationData.Attendees.Shuffle();
        //}

        public void Reload()
        {
            new InMemoryCache().Remove("Meetup.Attendees");
            LoadFromMeetup();
        }
    }
}