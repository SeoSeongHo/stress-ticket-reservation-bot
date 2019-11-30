using stress_bot.models.network;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace stress_bot.services.utils
{
    public static class NetworkUtil
    {
        private static HttpClientHandler _clientHandler = new HttpClientHandler
        {
            AllowAutoRedirect = false
        };

        public static async Task<HttpResponseModel> HttpRequestAsync(HttpRequestModel requestModel)
        {
            try
            {
                using (var client = new HttpClient(_clientHandler, false))
                using (var request = new HttpRequestMessage(requestModel.HttpMethod, requestModel.Url))
                using (var content = new StringContent(requestModel.Body ?? "", Encoding.UTF8))
                {
                    // Header
                    if (requestModel.Headers != null)
                    {
                        foreach (var header in requestModel.Headers)
                        {
                            if (header.Key.ToLower() == "content-type")
                            {
                                string[] contentTypes = header.Value.Split(';');
                                content.Headers.ContentType.MediaType = contentTypes[0];
                            }
                            else
                                request.Headers.Add(header.Key, header.Value);
                        }
                    }

                    // Body
                    if (!string.IsNullOrEmpty(requestModel.Body))
                        request.Content = content;

                    // Options
                    client.Timeout = TimeSpan.FromMilliseconds(requestModel.TimeoutMilis);

                    // Request, Response
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    var response = await client.SendAsync(request)
                        .ConfigureAwait(false);
                    string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    stopwatch.Stop();

                    return new HttpResponseModel
                    {
                        IsSuccess = true,
                        IsSuccessStatusCode = response.IsSuccessStatusCode,
                        StatusCode = response.StatusCode,
                        Headers = response.Headers,
                        Body = responseBody
                    };
                }
            }
            catch (Exception e)
            {
                return new HttpResponseModel
                {
                    IsSuccess = false,
                };
            }
        }
    }
}