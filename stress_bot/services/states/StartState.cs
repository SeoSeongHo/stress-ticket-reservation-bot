using Newtonsoft.Json;
using stress_bot.models.events;
using stress_bot.models.network;
using stress_bot.services.constants;
using stress_bot.services.utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static stress_bot.models.events.EventRequestModel;

namespace stress_bot.services.states
{
    public class StartState : BaseState
    {
        public StartState(EventCommon eventCommon) : base(BotStateType.start, eventCommon)
        {
        }

        public override BaseState MoveNextState()
        {
            this.currentState = new Random().Next(100) < 30 ?  BotStateType.move : BotStateType.end;
            return this;
        }

        public override BaseState Run()
        {
            var eventModel = new EventRequestModel
            {
                event_name = BotConstants.START_EVENT,
                event_datetime = DateTime.Now,
                event_common = this.eventCommon
            };

            var httpRequestModel = new HttpRequestModel
            {
                Url = "",
                HttpMethod = HttpMethod.Post,
                Headers = new Dictionary<string, string> { { "content-type", "application/json"} },
                Body = JsonConvert.SerializeObject(eventModel)
            };

            NetworkUtil.HttpRequestAsync(httpRequestModel).Wait();

            MoveNextState();

            return this.GetProcessor(this.currentState);
        }
    }
}
