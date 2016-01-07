using System.Configuration;

namespace swag.aurelia.api.Infrastructure
{
    public static class ApplicationSettings
    {
        public static string MeetupGroupName => GetAppConfig("MeetupGroupName");
        public static string MeetupRsvpUrl => GetAppConfig("MeetupRsvpUrl");
        public static string MeetupEventsUrl => GetAppConfig("MeetupEventsUrl");
        public static string MeetupApiKey => GetAppConfig("MeetupApiKey");

        public static string GetAppConfig(string key)
        {
            return ConfigurationManager.AppSettings[key] ?? string.Empty;
        }

    }
}