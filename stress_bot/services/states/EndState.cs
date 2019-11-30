using Newtonsoft.Json;
using stress_bot.models.events;
using stress_bot.models.network;
using stress_bot.services.constants;
using stress_bot.services.utils;
using System;
using System.Collections.Generic;
using System.Text;
using static stress_bot.models.events.EventRequestModel;

namespace stress_bot.services.states
{
    public class EndState : BaseState
    {
        public EndState(EventCommon eventCommon) : base(BotStateType.end, eventCommon)
        {
        }

        public override BaseState MoveNextState()
        {
            // TODO dequeue
        }

        public override BaseState Run()
        {
            var eventModel = new EventRequestModel
            {
                event_name = BotConstants.END_EVENT,
                event_datetime = DateTime.Now,
                event_common = this.eventCommon
            };

            var httpRequestModel = new HttpRequestModel
            {
                Url = "",
                HttpMethod = HttpMethod.Post,
                Headers = new Dictionary<string, string> { { "content-type", "application/json" } },
                Body = JsonConvert.SerializeObject(eventModel)
            };

            NetworkUtil.HttpRequestAsync(httpRequestModel).Wait();

            MoveNextState();

            return this.GetProcessor(this.currentState);
        }
    }
}
