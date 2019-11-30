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

        public BaseState GetProcessor(BotStateType botStateType)
        {
            switch (botStateType)
            {
                case BotStateType.start:
                    return new StartState(this.eventCommon).Run();
                case BotStateType.move:
                    return new MoveState(this.eventCommon).Run();
                case BotStateType.end:
                default:
                    return new EndState(this.eventCommon).Run();
            }
        }

        public abstract BaseState MoveNextState();
        public abstract BaseState Run();
    }
}