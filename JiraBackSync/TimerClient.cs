using System;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JiraBackSync.Data;
using Newtonsoft.Json;
using Timer = JiraBackSync.Data.Timer;

namespace JiraBackSync
{
    [GeneratedCode("NSwag", "11.4.3.0")]
    public class TimerClient
    {
        private readonly Lazy<JsonSerializerSettings> _settings;

        public TimerClient()
        {
            _settings = new Lazy<JsonSerializerSettings>(() =>
            {
                var settings = new JsonSerializerSettings();
                UpdateJsonSerializerSettings(settings);
                return settings;
            });
        }

        public string BaseUrl { get; set; } = "https://app.tmetric.com";

        private static void UpdateJsonSerializerSettings(JsonSerializerSettings settings)
        {
        }

        private static void PrepareRequest(HttpClient client, HttpRequestMessage request, string url)
        {
        }

        private static void PrepareRequest(HttpClient client, HttpRequestMessage request, StringBuilder urlBuilder)
        {
        }

        private static void ProcessResponse(HttpClient client, HttpResponseMessage response)
        {
        }

        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public Task<Timer> GetTimerAsync(int accountId, int? userProfileId)
        {
            return GetTimerAsync(accountId, userProfileId, CancellationToken.None);
        }

        /// <param name="userProfileId"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <param name="accountId"></param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task<Timer> GetTimerAsync(int accountId, int? userProfileId, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl).Append("/api/accounts/{accountId}/timer?");
            urlBuilder.Replace("{accountId}", Uri.EscapeDataString(Convert.ToString(accountId, CultureInfo.InvariantCulture)));
            if (userProfileId != null)
                urlBuilder.Append("userProfileId=")
                    .Append(
                        Uri.EscapeDataString(Convert.ToString(userProfileId.Value, CultureInfo.InvariantCulture)))
                    .Append("&");
            urlBuilder.Length--;

            var client = new HttpClient();
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Method = new HttpMethod("GET");
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client, request, urlBuilder);
                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client, request, url);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers = response.Headers.ToDictionary(h => h.Key, h => h.Value);
                        foreach (var item in response.Content.Headers)
                            headers[item.Key] = item.Value;

                        ProcessResponse(client, response);

                        var status = ((int)response.StatusCode).ToString();
                        if (status == "200")
                        {
                            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            try
                            {
                                var result = JsonConvert.DeserializeObject<Timer>(responseData, _settings.Value);
                                return result;
                            }
                            catch (Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status, responseData, headers, exception);
                            }
                        }
                        else
                        if (status != "200" && status != "204")
                        {
                            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", status, responseData, headers, null);
                        }

                        return default(Timer);
                    }
                    finally
                    {
                        response?.Dispose();
                    }
                }
            }
            finally
            {
                client.Dispose();
            }
        }

        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public Task<object> PutTimerAsync(int accountId, Timer timer)
        {
            return PutTimerAsync(accountId, timer, CancellationToken.None);
        }

        /// <param name="timer"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <param name="accountId"></param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task<object> PutTimerAsync(int accountId, Timer timer, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl).Append("/api/accounts/{accountId}/timer");
            urlBuilder.Replace("{accountId}", Uri.EscapeDataString(Convert.ToString(accountId, CultureInfo.InvariantCulture)));

            var client = new HttpClient();
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(timer, _settings.Value));
                    content.Headers.ContentType.MediaType = "application/json";
                    request.Content = content;
                    request.Method = new HttpMethod("PUT");
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client, request, urlBuilder);
                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client, request, url);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers = response.Headers.ToDictionary(h => h.Key, h => h.Value);
                        foreach (var item in response.Content.Headers)
                            headers[item.Key] = item.Value;

                        ProcessResponse(client, response);

                        var status = ((int)response.StatusCode).ToString();
                        if (status == "200")
                        {
                            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            try
                            {
                                var result = JsonConvert.DeserializeObject<object>(responseData, _settings.Value);
                                return result;
                            }
                            catch (Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status, responseData, headers, exception);
                            }
                        }
                        else
                        if (status != "200" && status != "204")
                        {
                            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", status, responseData, headers, null);
                        }

                        return default(object);
                    }
                    finally
                    {
                        response?.Dispose();
                    }
                }
            }
            finally
            {
                client.Dispose();
            }
        }

        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public Task<object> PostTimerAsync(int accountId, WebToolIssueTimer externalIssue)
        {
            return PostTimerAsync(accountId, externalIssue, CancellationToken.None);
        }

        /// <param name="externalIssue"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <param name="accountId"></param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task<object> PostTimerAsync(int accountId, WebToolIssueTimer externalIssue, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl).Append("/api/accounts/{accountId}/timer/external");
            urlBuilder.Replace("{accountId}", Uri.EscapeDataString(Convert.ToString(accountId, CultureInfo.InvariantCulture)));

            var client = new HttpClient();
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(externalIssue, _settings.Value));
                    content.Headers.ContentType.MediaType = "application/json";
                    request.Content = content;
                    request.Method = new HttpMethod("POST");
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client, request, urlBuilder);
                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client, request, url);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers = response.Headers.ToDictionary(h => h.Key, h => h.Value);
                        foreach (var item in response.Content.Headers)
                            headers[item.Key] = item.Value;

                        ProcessResponse(client, response);

                        var status = ((int)response.StatusCode).ToString();
                        if (status == "200")
                        {
                            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            try
                            {
                                var result = JsonConvert.DeserializeObject<object>(responseData, _settings.Value);
                                return result;
                            }
                            catch (Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status, responseData, headers, exception);
                            }
                        }
                        else
                        if (status != "200" && status != "204")
                        {
                            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", status, responseData, headers, null);
                        }

                        return default(object);
                    }
                    finally
                    {
                        response?.Dispose();
                    }
                }
            }
            finally
            {
                client.Dispose();
            }
        }

    }
}