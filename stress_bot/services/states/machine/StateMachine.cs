using System;
using System.Collections.Generic;
using System.Text;

namespace stress_bot.services.states.machine
{
    public class StateMachine
    {
        private Queue<BaseState> queue { get; set; }
        
        public StateMachine(List<BaseState> states)
        {
            this.queue = new Queue<BaseState>(states);
        }

        public void Run()
        {
            while (this.queue.Count != 0)
            {
                if(queue.TryDequeue(out var currentState))
                {
                    currentState = currentState.TriggerState();
                    currentState.MoveNextState(queue);
                }
            }
        }
    }
}
