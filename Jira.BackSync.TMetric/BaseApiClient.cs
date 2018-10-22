using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Jira.BackSync.TMetric
{
    public abstract class BaseApiClient
    {
        protected BaseApiClient(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        public string BaseUrl { get; protected set; }

        protected virtual HttpClient PrepareHttpClient()
        {
            return new HttpClient();
        }

        protected virtual void UpdateJsonSerializerSettings(JsonSerializerSettings settings)
        {
        }

        protected virtual void PrepareRequest(HttpClient client, HttpRequestMessage request, string url)
        {
        }

        protected virtual void PrepareRequest(HttpClient client, HttpRequestMessage request, StringBuilder urlBuilder)
        {
        }

        protected virtual void ProcessResponse(HttpClient client, HttpResponseMessage response)
        {
        }
    }
}