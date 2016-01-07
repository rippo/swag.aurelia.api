using System.Collections.Generic;

namespace swag.aurelia.api.Models
{
    public class EventDto
    {
        public List<EventItemDto> Results { get; set; }
    }

    public class EventItemDto
    {
        public string Status { get; set; }
        public string Id { get; set; }
        public int YesRsvpCount { get; set; }
    }
}