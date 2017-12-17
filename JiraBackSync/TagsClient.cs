using System;
using System.CodeDom.Compiler;
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
    public class TagsClient
    {
        private readonly Lazy<JsonSerializerSettings> _settings;

        public TagsClient()
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
        public Task<ObservableCollection<Tag>> GetTagsAsync(int accountId)
        {
            return GetTagsAsync(accountId, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task<ObservableCollection<Tag>> GetTagsAsync(int accountId, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl).Append("/api/accounts/{accountId}/tags");
            urlBuilder.Replace("{accountId}", Uri.EscapeDataString(Convert.ToString(accountId, CultureInfo.InvariantCulture)));

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
                                var result = JsonConvert.DeserializeObject<ObservableCollection<Tag>>(responseData, _settings.Value);
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

                        return default(ObservableCollection<Tag>);
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
        public Task<Tag> PostTagAsync(Tag clientTag, string accountId)
        {
            return PostTagAsync(clientTag, accountId, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task<Tag> PostTagAsync(Tag clientTag, string accountId, CancellationToken cancellationToken)
        {
            if (accountId == null)
                throw new ArgumentNullException(nameof(accountId));

            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl).Append("/api/accounts/{accountId}/tags");
            urlBuilder.Replace("{accountId}", Uri.EscapeDataString(Convert.ToString(accountId, CultureInfo.InvariantCulture)));

            var client = new HttpClient();
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(clientTag, _settings.Value));
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
                                var result = JsonConvert.DeserializeObject<Tag>(responseData, _settings.Value);
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

                        return default(Tag);
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

        /// <returns>No Content</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public Task PutTagAsync(Tag clientTag, string accountId, string tagId)
        {
            return PutTagAsync(clientTag, accountId, tagId, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>No Content</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task PutTagAsync(Tag clientTag, string accountId, string tagId, CancellationToken cancellationToken)
        {
            if (accountId == null)
                throw new ArgumentNullException(nameof(accountId));

            if (tagId == null)
                throw new ArgumentNullException(nameof(tagId));

            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl).Append("/api/accounts/{accountId}/tags/{tagId}");
            urlBuilder.Replace("{accountId}", Uri.EscapeDataString(Convert.ToString(accountId, CultureInfo.InvariantCulture)));
            urlBuilder.Replace("{tagId}", Uri.EscapeDataString(Convert.ToString(tagId, CultureInfo.InvariantCulture)));

            var client = new HttpClient();
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(clientTag, _settings.Value));
                    content.Headers.ContentType.MediaType = "application/json";
                    request.Content = content;
                    request.Method = new HttpMethod("PUT");

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
                        if (status == "204")
                        {
                        }
                        else
                        if (status != "200" && status != "204")
                        {
                            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", status, responseData, headers, null);
                        }
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

        /// <returns>No Content</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public Task DeleteTagAsync(int accountId, int tagId)
        {
            return DeleteTagAsync(accountId, tagId, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>No Content</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task DeleteTagAsync(int accountId, int tagId, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl).Append("/api/accounts/{accountId}/tags/{tagId}");
            urlBuilder.Replace("{accountId}", Uri.EscapeDataString(Convert.ToString(accountId, CultureInfo.InvariantCulture)));
            urlBuilder.Replace("{tagId}", Uri.EscapeDataString(Convert.ToString(tagId, CultureInfo.InvariantCulture)));

            var client = new HttpClient();
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Method = new HttpMethod("DELETE");

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
                        if (status == "204")
                        {
                        }
                        else
                        if (status != "200" && status != "204")
                        {
                            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", status, responseData, headers, null);
                        }
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