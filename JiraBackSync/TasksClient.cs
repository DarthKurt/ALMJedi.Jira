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
    public class TasksClient
    {
        private readonly Lazy<JsonSerializerSettings> _settings;

        public TasksClient()
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

        /// <param name="filterAssigneeList">Gets or sets profile list for report filter.</param>
        /// <param name="filterGroupList">Gets or sets group list for report filter.</param>
        /// <param name="filterProjectList">Gets or sets project list for report filter.</param>
        /// <param name="filterTagList">Gets or sets tag list for report filter.</param>
        /// <param name="filterCompleted">Gets or sets status for task filter.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public Task<ObservableCollection<ProjectTask>> GetTasksAsync(int accountId, IEnumerable<int> filterAssigneeList, IEnumerable<int> filterGroupList, IEnumerable<int> filterProjectList, IEnumerable<int> filterTagList, bool? filterCompleted)
        {
            return GetTasksAsync(accountId, filterAssigneeList, filterGroupList, filterProjectList, filterTagList, filterCompleted, CancellationToken.None);
        }

        /// <param name="filterAssigneeList">Gets or sets profile list for report filter.</param>
        /// <param name="filterGroupList">Gets or sets group list for report filter.</param>
        /// <param name="filterProjectList">Gets or sets project list for report filter.</param>
        /// <param name="filterTagList">Gets or sets tag list for report filter.</param>
        /// <param name="filterCompleted">Gets or sets status for task filter.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task<ObservableCollection<ProjectTask>> GetTasksAsync(int accountId, IEnumerable<int> filterAssigneeList, IEnumerable<int> filterGroupList, IEnumerable<int> filterProjectList, IEnumerable<int> filterTagList, bool? filterCompleted, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl).Append("/api/accounts/{accountId}/tasks?");
            urlBuilder.Replace("{accountId}", Uri.EscapeDataString(Convert.ToString(accountId, CultureInfo.InvariantCulture)));
            if (filterAssigneeList != null) foreach (var item in filterAssigneeList) { urlBuilder.Append("filter.assigneeList=").Append(Uri.EscapeDataString(Convert.ToString(item, CultureInfo.InvariantCulture))).Append("&"); }
            if (filterGroupList != null) foreach (var item in filterGroupList) { urlBuilder.Append("filter.groupList=").Append(Uri.EscapeDataString(Convert.ToString(item, CultureInfo.InvariantCulture))).Append("&"); }
            if (filterProjectList != null) foreach (var item in filterProjectList) { urlBuilder.Append("filter.projectList=").Append(Uri.EscapeDataString(Convert.ToString(item, CultureInfo.InvariantCulture))).Append("&"); }
            if (filterTagList != null) foreach (var item in filterTagList) { urlBuilder.Append("filter.tagList=").Append(Uri.EscapeDataString(Convert.ToString(item, CultureInfo.InvariantCulture))).Append("&"); }
            if (filterCompleted != null) urlBuilder.Append("filter.completed=").Append(Uri.EscapeDataString(Convert.ToString(filterCompleted.Value, CultureInfo.InvariantCulture))).Append("&");
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
                                var result = JsonConvert.DeserializeObject<ObservableCollection<ProjectTask>>(responseData, _settings.Value);
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

                        return default(ObservableCollection<ProjectTask>);
                    }
                    finally
                    {
                        response.Dispose();
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
        public Task<ProjectTask> PostTaskAsync(int accountId, ProjectTask task)
        {
            return PostTaskAsync(accountId, task, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task<ProjectTask> PostTaskAsync(int accountId, ProjectTask task, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl).Append("/api/accounts/{accountId}/tasks");
            urlBuilder.Replace("{accountId}", Uri.EscapeDataString(Convert.ToString(accountId, CultureInfo.InvariantCulture)));

            var client = new HttpClient();
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(task, _settings.Value));
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
                                var result = JsonConvert.DeserializeObject<ProjectTask>(responseData, _settings.Value);
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

                        return default(ProjectTask);
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
        public Task<ProjectTask> GetTaskAsync(int accountId, int taskId)
        {
            return GetTaskAsync(accountId, taskId, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task<ProjectTask> GetTaskAsync(int accountId, int taskId, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl).Append("/api/accounts/{accountId}/tasks/{taskId}");
            urlBuilder.Replace("{accountId}", Uri.EscapeDataString(Convert.ToString(accountId, CultureInfo.InvariantCulture)));
            urlBuilder.Replace("{taskId}", Uri.EscapeDataString(Convert.ToString(taskId, CultureInfo.InvariantCulture)));

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
                                var result = JsonConvert.DeserializeObject<ProjectTask>(responseData, _settings.Value);
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

                        return default(ProjectTask);
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
        public Task PutTaskAsync(int accountId, int taskId, ProjectTask task)
        {
            return PutTaskAsync(accountId, taskId, task, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>No Content</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task PutTaskAsync(int accountId, int taskId, ProjectTask task, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl).Append("/api/accounts/{accountId}/tasks/{taskId}");
            urlBuilder.Replace("{accountId}", Uri.EscapeDataString(Convert.ToString(accountId, CultureInfo.InvariantCulture)));
            urlBuilder.Replace("{taskId}", Uri.EscapeDataString(Convert.ToString(taskId, CultureInfo.InvariantCulture)));

            var client = new HttpClient();
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(task, _settings.Value));
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

        /// <returns>No Content</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public Task DeleteTaskAsync(int accountId, int taskId)
        {
            return DeleteTaskAsync(accountId, taskId, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>No Content</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task DeleteTaskAsync(int accountId, int taskId, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl).Append("/api/accounts/{accountId}/tasks/{taskId}");
            urlBuilder.Replace("{accountId}", Uri.EscapeDataString(Convert.ToString(accountId, CultureInfo.InvariantCulture)));
            urlBuilder.Replace("{taskId}", Uri.EscapeDataString(Convert.ToString(taskId, CultureInfo.InvariantCulture)));

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
                        response.Dispose();
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
        public Task<object> PutTasksAsync(int accountId, IEnumerable<int> taskId, IEnumerable<ProjectTask> tasks)
        {
            return PutTasksAsync(accountId, taskId, tasks, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task<object> PutTasksAsync(int accountId, IEnumerable<int> taskId, IEnumerable<ProjectTask> tasks, CancellationToken cancellationToken)
        {
            if (taskId == null)
                throw new ArgumentNullException(nameof(taskId));

            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl).Append("/api/accounts/{accountId}/tasks/bulk?");
            urlBuilder.Replace("{accountId}", Uri.EscapeDataString(Convert.ToString(accountId, CultureInfo.InvariantCulture)));
            foreach (var item in taskId) { urlBuilder.Append("taskId=").Append(Uri.EscapeDataString(Convert.ToString(item, CultureInfo.InvariantCulture))).Append("&"); }
            urlBuilder.Length--;

            var client = new HttpClient();
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(tasks, _settings.Value));
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
                        response.Dispose();
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