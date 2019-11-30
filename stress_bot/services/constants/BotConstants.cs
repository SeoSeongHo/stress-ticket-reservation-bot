using System;
using System.Collections.Generic;
using System.Text;

namespace stress_bot.services.constants
{
    public class BotConstants
    {
        public static int THREAD_NUM = 1000;
        public static string START_EVENT = "a:start";
        public static string END_EVENT = "a:end";
        public static string MOVE_EVENT = "b:move";
    }

    public enum BotStateType
    {
        start,
        move,
        end
    }

    public enum PublicTransport
    {
        no,
        subway,
        bus,
        bicycle
    }
}