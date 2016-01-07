using System;
using RestSharp;

namespace swag.aurelia.api.Infrastructure
{
    public class MeetupApiCall
    {
        private readonly string meetupApiKey;
        readonly Uri baseUrl = new Uri("https://api.meetup.com/2");

        public MeetupApiCall(string meetupApiKey)
        {
            this.meetupApiKey = meetupApiKey;
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient { BaseUrl = baseUrl };
            request.AddUrlSegment("key", meetupApiKey);

            var response = client.Execute<T>(request);

            //TODO Not checking for response.ErrorException != null

            return response.Data;
        }

    }
}