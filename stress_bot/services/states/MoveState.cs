using Newtonsoft.Json;
using stress_bot.models.events;
using stress_bot.models.network;
using stress_bot.services.constants;
using stress_bot.services.utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using static stress_bot.models.events.EventRequestModel;

namespace stress_bot.services.states
{
    public class MoveState : BaseState
    {
        public MoveState(EventCommon eventCommon) : base(BotStateType.start, eventCommon)
        {
        }

        public override void MoveNextState(Queue<BaseState> queue)
        {
            this.currentState = new Random().Next(100) < 30 ? BotStateType.move : BotStateType.end;
            queue.Enqueue(this);
        }

        public override BaseState Run()
        {
            var eventModel = new EventRequestModel
            {
                event_name = BotConstants.MOVE_EVENT,
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

            return this;
        }
    }
}
