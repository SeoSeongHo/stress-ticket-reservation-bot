using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace stress_bot.models.network
{
    public class HttpResponseModel
    {
        public bool IsSuccess { get; set; }
        public bool IsSuccessStatusCode { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public HttpResponseHeaders Headers { get; set; }
        public string Body { get; set; }
    }
}
