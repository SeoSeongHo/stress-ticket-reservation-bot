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
    public class EndState : BaseState
    {
        public EndState(EventCommon eventCommon) : base(BotStateType.end, eventCommon)
        {
        }

        public override void MoveNextState(Queue<BaseState> queue)
        {
            
        }

        public override BaseState Run()
        {
            return this;
        }
    }
}
