using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace stress_bot.models.network
{
    public class HttpRequestModel
    {
        public int TimeoutMilis { get; set; } = 10000;
        public string Url { get; set; }
        public HttpMethod HttpMethod { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public string Body { get; set; }
    }
}