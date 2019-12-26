using System;
using System.Collections.Generic;
using System.Text;

namespace stress_bot.services.constants
{
    public class BotConstants
    {
        public readonly static int THREAD_NUM = 1000;

        #region event name
        public readonly static string START_EVENT = "a:start";
        public readonly static string END_EVENT = "a:end";
        public readonly static string LOGIN_EVENT = "b:login";
        public readonly static string VIEW_PAGE_EVENT = "b:view_page";
        public readonly static string RESERVE_TICKET_EVENT = "c:reserve_ticket";
        public readonly static string LOGOUT_EVENT = "b:logout";
        #endregion

        public readonly static Dictionary<int, List<string>> sampleEventNames = new Dictionary<int, List<string>>
        {
            {0, new List<string>{ START_EVENT, LOGIN_EVENT, VIEW_PAGE_EVENT, VIEW_PAGE_EVENT, RESERVE_TICKET_EVENT, END_EVENT } },
            {1, new List<string>{ START_EVENT, LOGIN_EVENT, VIEW_PAGE_EVENT, VIEW_PAGE_EVENT, RESERVE_TICKET_EVENT, END_EVENT } },
            {2, new List<string>{ START_EVENT, LOGIN_EVENT, VIEW_PAGE_EVENT, VIEW_PAGE_EVENT, RESERVE_TICKET_EVENT } },
            {3, new List<string>{ START_EVENT, LOGIN_EVENT, VIEW_PAGE_EVENT, LOGOUT_EVENT, VIEW_PAGE_EVENT, RESERVE_TICKET_EVENT } },
            {4, new List<string>{ START_EVENT, LOGIN_EVENT, VIEW_PAGE_EVENT, VIEW_PAGE_EVENT, LOGOUT_EVENT, RESERVE_TICKET_EVENT, END_EVENT } },
            {5, new List<string>{ START_EVENT, LOGIN_EVENT, RESERVE_TICKET_EVENT } },
            {6, new List<string>{ START_EVENT, LOGIN_EVENT, RESERVE_TICKET_EVENT } }
        };
    }

    public enum BotStateType
    {
        start,
        events,
        end
    }
}