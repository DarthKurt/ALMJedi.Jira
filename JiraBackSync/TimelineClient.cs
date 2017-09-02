using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JiraBackSync.Data;
using Newtonsoft.Json;

namespace JiraBackSync
{
    [GeneratedCode("NSwag", "11.4.3.0")]
    public class TimelineClient
    {
        private readonly Lazy<JsonSerializerSettings> _settings;

        public TimelineClient()
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
        public Task<ObservableCollection<TimelineEntry>> GetTimelineEntriesAsync(int accountId, int userProfileId, DateTime? timeRangeStartTime, DateTime? timeRangeEndTime)
        {
            return GetTimelineEntriesAsync(accountId, userProfileId, timeRangeStartTime, timeRangeEndTime, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task<ObservableCollection<TimelineEntry>> GetTimelineEntriesAsync(int accountId, int userProfileId, DateTime? timeRangeStartTime, DateTime? timeRangeEndTime, CancellationToken cancellationToken)
        {
            if (accountId == null)
                throw new ArgumentNullException(nameof(accountId));

            if (userProfileId == null)
                throw new ArgumentNullException(nameof(userProfileId));

            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl).Append("/api/timeline/{accountId}?");
            urlBuilder.Replace("{accountId}", Uri.EscapeDataString(Convert.ToString(accountId, CultureInfo.InvariantCulture)));
            urlBuilder.Append("userProfileId=").Append(Uri.EscapeDataString(Convert.ToString(userProfileId, CultureInfo.InvariantCulture))).Append("&");
            if (timeRangeStartTime != null) urlBuilder.Append("timeRange.startTime=").Append(Uri.EscapeDataString(timeRangeStartTime.Value.ToString("s", CultureInfo.InvariantCulture))).Append("&");
            if (timeRangeEndTime != null) urlBuilder.Append("timeRange.endTime=").Append(Uri.EscapeDataString(timeRangeEndTime.Value.ToString("s", CultureInfo.InvariantCulture))).Append("&");
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
                            var result = default(ObservableCollection<TimelineEntry>);
                            try
                            {
                                result = JsonConvert.DeserializeObject<ObservableCollection<TimelineEntry>>(responseData, _settings.Value);
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

                        return default(ObservableCollection<TimelineEntry>);
                    }
                    finally
                    {
                        if (response != null)
                            response.Dispose();
                    }
                }
            }
            finally
            {
                if (client != null)
                    client.Dispose();
            }
        }

        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public Task<object> PostTimelineEntriesAsync(int accountId, IEnumerable<TimelineEntry> timelineEntries)
        {
            return PostTimelineEntriesAsync(accountId, timelineEntries, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task<object> PostTimelineEntriesAsync(int accountId, IEnumerable<TimelineEntry> timelineEntries, CancellationToken cancellationToken)
        {
            if (accountId == null)
                throw new ArgumentNullException(nameof(accountId));

            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl).Append("/api/timeline/{accountId}");
            urlBuilder.Replace("{accountId}", Uri.EscapeDataString(Convert.ToString(accountId, CultureInfo.InvariantCulture)));

            var client = new HttpClient();
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(timelineEntries, _settings.Value));
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
                            var result = default(object);
                            try
                            {
                                result = JsonConvert.DeserializeObject<object>(responseData, _settings.Value);
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
                        if (response != null)
                            response.Dispose();
                    }
                }
            }
            finally
            {
                if (client != null)
                    client.Dispose();
            }
        }

    }
}