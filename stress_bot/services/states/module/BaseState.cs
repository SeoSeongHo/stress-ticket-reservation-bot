using stress_bot.models.events;
using stress_bot.services.constants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static stress_bot.models.events.EventRequestModel;

namespace stress_bot.services.states
{
    public abstract class BaseState
    {
        protected BotStateType currentState;
        protected EventCommon eventCommon;

        public BaseState(BotStateType currentState, EventCommon eventCommon) 
        {
            this.currentState = currentState;
            this.eventCommon = eventCommon;
        }

        public BaseState TriggerState()
        {
            switch (currentState)
            {
                case BotStateType.start:
                default:
                    return new StartState(this.eventCommon).Run();
                case BotStateType.events:
                    return new EventState(this.eventCommon).Run();
                case BotStateType.end:
                    return new EndState(this.eventCommon).Run();
            }
        }

        public abstract void MoveNextState(Queue<BaseState> queue);
        public abstract BaseState Run();
    }
}