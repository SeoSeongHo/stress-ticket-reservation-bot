using stress_bot.services.constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace stress_bot.models.events
{
    public class EventRequestModel
    {
        public string event_name { get; set; }
        public PublicTransport transport { get; set; }
        public DateTime event_datetime { get; set; }
        public EventCommon event_common { get; set; }

        public class EventCommon
        {
            public string event_id { get; set; }
        }
    }
}
