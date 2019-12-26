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
    public class EventState : BaseState
    {
        public EventState(EventCommon eventCommon) : base(BotStateType.start, eventCommon)
        {
        }

        public override void MoveNextState(Queue<BaseState> queue)
        {
            this.currentState = new Random().Next(100) < 30 ? BotStateType.events : BotStateType.end;
            queue.Enqueue(this);
        }

        public override BaseState Run()
        {
            var eventNames = BotConstants.sampleEventNames[new Random().Next(6)];

            var eventModel = new EventRequestModel
            {
                event_datetime = DateTime.Now,
                event_common = this.eventCommon,
                event_dic = new Dictionary<string, string>()
            };

            foreach (var eventName in eventNames)
            {
                eventModel.event_name = eventName;

                if (eventName == BotConstants.LOGIN_EVENT)
                    eventModel.event_dic.Add("user_id", Guid.NewGuid().ToString());

                if (eventName == BotConstants.LOGOUT_EVENT)
                    eventModel.event_dic.Remove("user_id");
            }

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
