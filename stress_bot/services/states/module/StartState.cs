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

        public override void MoveNextState(Queue<BaseState> queue)
        {
            this.currentState = BotStateType.events;
            queue.Enqueue(this);
        }

        public override BaseState Run()
        {
            this.eventCommon.event_id = Guid.NewGuid().ToString();

            return this;
        }
    }
}
