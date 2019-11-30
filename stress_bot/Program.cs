using stress_bot.services.constants;
using stress_bot.services.states;
using stress_bot.services.states.machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stress_bot
{
    class Program
    {
        static void Main(string[] args)
        {
            var states = new List<BaseState>();
            Task.WhenAll(
                Enumerable.Range(0, BotConstants.THREAD_NUM).Select(
                    i => Task.Run(
                        () => {
                        var stateMachine = new StateMachine(states.GetRange(10, 10));
                            stateMachine.Run();
                        }
                        )
                    )
                ).Wait();
        }
    }
}
