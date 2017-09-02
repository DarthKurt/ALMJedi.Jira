using System.Net.Http;
using System.Text;
using JiraBackSync.Properties;
using Newtonsoft.Json;

namespace JiraBackSync
{
    public class BaseTmetricApiClient
    {
        public string BaseUrl { get; set; } = Settings.Default.BaseTmetricApiUrl;

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