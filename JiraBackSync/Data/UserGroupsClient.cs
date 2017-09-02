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
using Newtonsoft.Json;

namespace JiraBackSync.Data
{
    [GeneratedCode("NSwag", "11.4.3.0")]
    public class UserGroupsClient
    {
        private readonly Lazy<JsonSerializerSettings> _settings;

        public UserGroupsClient()
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
        public Task<UserGroup> GetGroupAsync(int accountId, int groupId)
        {
            return GetGroupAsync(accountId, groupId, CancellationToken.None);
        }

        /// <param name="groupId"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <param name="accountId"></param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task<UserGroup> GetGroupAsync(int accountId, int groupId, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl).Append("/api/accounts/{accountId}/usergroups/{groupId}");
            urlBuilder.Replace("{accountId}", Uri.EscapeDataString(Convert.ToString(accountId, CultureInfo.InvariantCulture)));
            urlBuilder.Replace("{groupId}", Uri.EscapeDataString(Convert.ToString(groupId, CultureInfo.InvariantCulture)));

            var client_ = new HttpClient();
            try
            {
                using (var request_ = new HttpRequestMessage())
                {
                    request_.Method = new HttpMethod("GET");
                    request_.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder);
                    var url = urlBuilder.ToString();
                    request_.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url);

                    var response = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers = response.Headers.ToDictionary(h_ => h_.Key, h_ => h_.Value);
                        foreach (var item in response.Content.Headers)
                            headers[item.Key] = item.Value;

                        ProcessResponse(client_, response);

                        var status_ = ((int)response.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            try
                            {
                                var result_ = JsonConvert.DeserializeObject<UserGroup>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers, exception);
                            }
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", status_, responseData_, headers, null);
                        }

                        return default(UserGroup);
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
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <returns>No Content</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public Task PutGroupAsync(UserGroup clientGroup, string accountId, string groupId)
        {
            return PutGroupAsync(clientGroup, accountId, groupId, CancellationToken.None);
        }

        /// <param name="groupId"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <param name="clientGroup"></param>
        /// <param name="accountId"></param>
        /// <returns>No Content</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task PutGroupAsync(UserGroup clientGroup, string accountId, string groupId, CancellationToken cancellationToken)
        {
            if (accountId == null)
                throw new ArgumentNullException(nameof(accountId));

            if (groupId == null)
                throw new ArgumentNullException(nameof(groupId));

            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl).Append("/api/accounts/{accountId}/usergroups/{groupId}");
            urlBuilder.Replace("{accountId}", Uri.EscapeDataString(Convert.ToString(accountId, CultureInfo.InvariantCulture)));
            urlBuilder.Replace("{groupId}", Uri.EscapeDataString(Convert.ToString(groupId, CultureInfo.InvariantCulture)));

            var client_ = new HttpClient();
            try
            {
                using (var request_ = new HttpRequestMessage())
                {
                    var content_ = new StringContent(JsonConvert.SerializeObject(clientGroup, _settings.Value));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new HttpMethod("PUT");

                    PrepareRequest(client_, request_, urlBuilder);
                    var url = urlBuilder.ToString();
                    request_.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url);

                    var response = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers = response.Headers.ToDictionary(h_ => h_.Key, h_ => h_.Value);
                        foreach (var item in response.Content.Headers)
                            headers[item.Key] = item.Value;

                        ProcessResponse(client_, response);

                        var status_ = ((int)response.StatusCode).ToString();
                        if (status_ == "204")
                        {
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", status_, responseData_, headers, null);
                        }
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
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <returns>No Content</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public Task DeleteGroupAsync(int accountId, int groupId)
        {
            return DeleteGroupAsync(accountId, groupId, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>No Content</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task DeleteGroupAsync(int accountId, int groupId, CancellationToken cancellationToken)
        {
            if (accountId == null)
                throw new ArgumentNullException(nameof(accountId));

            if (groupId == null)
                throw new ArgumentNullException(nameof(groupId));

            var urlBuilder_ = new StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/api/accounts/{accountId}/usergroups/{groupId}");
            urlBuilder_.Replace("{accountId}", Uri.EscapeDataString(Convert.ToString(accountId, CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{groupId}", Uri.EscapeDataString(Convert.ToString(groupId, CultureInfo.InvariantCulture)));

            var client_ = new HttpClient();
            try
            {
                using (var request_ = new HttpRequestMessage())
                {
                    request_.Method = new HttpMethod("DELETE");

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url = urlBuilder_.ToString();
                    request_.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url);

                    var response = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers = response.Headers.ToDictionary(h_ => h_.Key, h_ => h_.Value);
                        foreach (var item in response.Content.Headers)
                            headers[item.Key] = item.Value;

                        ProcessResponse(client_, response);

                        var status_ = ((int)response.StatusCode).ToString();
                        if (status_ == "204")
                        {
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", status_, responseData_, headers, null);
                        }
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
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public Task<ObservableCollection<UserGroup>> GetGroupsAsync(int accountId)
        {
            return GetGroupsAsync(accountId, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task<ObservableCollection<UserGroup>> GetGroupsAsync(int accountId, CancellationToken cancellationToken)
        {
            if (accountId == null)
                throw new ArgumentNullException(nameof(accountId));

            var urlBuilder_ = new StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/api/accounts/{accountId}/usergroups");
            urlBuilder_.Replace("{accountId}", Uri.EscapeDataString(Convert.ToString(accountId, CultureInfo.InvariantCulture)));

            var client_ = new HttpClient();
            try
            {
                using (var request_ = new HttpRequestMessage())
                {
                    request_.Method = new HttpMethod("GET");
                    request_.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url = urlBuilder_.ToString();
                    request_.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url);

                    var response = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers = response.Headers.ToDictionary(h_ => h_.Key, h_ => h_.Value);
                        foreach (var item in response.Content.Headers)
                            headers[item.Key] = item.Value;

                        ProcessResponse(client_, response);

                        var status_ = ((int)response.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ObservableCollection<UserGroup>);
                            try
                            {
                                result_ = JsonConvert.DeserializeObject<ObservableCollection<UserGroup>>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers, exception);
                            }
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", status_, responseData_, headers, null);
                        }

                        return default(ObservableCollection<UserGroup>);
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
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public Task<UserGroup> PostGroupAsync(UserGroup clientGroup, string accountId)
        {
            return PostGroupAsync(clientGroup, accountId, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task<UserGroup> PostGroupAsync(UserGroup clientGroup, string accountId, CancellationToken cancellationToken)
        {
            if (accountId == null)
                throw new ArgumentNullException(nameof(accountId));

            var urlBuilder_ = new StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/api/accounts/{accountId}/usergroups");
            urlBuilder_.Replace("{accountId}", Uri.EscapeDataString(Convert.ToString(accountId, CultureInfo.InvariantCulture)));

            var client_ = new HttpClient();
            try
            {
                using (var request_ = new HttpRequestMessage())
                {
                    var content_ = new StringContent(JsonConvert.SerializeObject(clientGroup, _settings.Value));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new HttpMethod("POST");
                    request_.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url = urlBuilder_.ToString();
                    request_.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url);

                    var response = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers = response.Headers.ToDictionary(h_ => h_.Key, h_ => h_.Value);
                        foreach (var item in response.Content.Headers)
                            headers[item.Key] = item.Value;

                        ProcessResponse(client_, response);

                        var status_ = ((int)response.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(UserGroup);
                            try
                            {
                                result_ = JsonConvert.DeserializeObject<UserGroup>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers, exception);
                            }
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", status_, responseData_, headers, null);
                        }

                        return default(UserGroup);
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
                if (client_ != null)
                    client_.Dispose();
            }
        }

    }
}