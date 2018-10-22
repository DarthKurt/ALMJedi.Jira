using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JiraBackSync.TMetric.Data;
using Newtonsoft.Json;

namespace JiraBackSync.TMetric
{
    internal sealed class ReportDetailedClient : BaseApiClient
    {
        private readonly Lazy<JsonSerializerSettings> _settings;
        private readonly string _apiKey;

        public ReportDetailedClient(string baseUrl, string apiKey):
            base(baseUrl)
        {
            _apiKey = apiKey;
            _settings = new Lazy<JsonSerializerSettings>(() =>
            {
                var settings = new JsonSerializerSettings();
                UpdateJsonSerializerSettings(settings);
                return settings;
            });
        }

        protected override HttpClient PrepareHttpClient()
        {
            var baseAddress = new Uri(BaseUrl);
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler
            {
                CookieContainer = cookieContainer
            };

            var client = new HttpClient(handler)
            {
                BaseAddress = baseAddress
            };

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            return client;
        }

        /// <summary>Gets the detailed report.</summary>
        /// <param name="projectListReportFilter">Gets or sets project list for report filter.</param>
        /// <param name="tagListReportFilter">Gets or sets tag list for report filter.</param>
        /// <param name="groupColumnNamesReportFilter">Gets or sets the group column names.</param>
        /// <param name="activeProjectsOnlyReportFlag">Gets or sets the value indicating that only active projects should be returned.</param>
        /// <param name="noRoundingReportFlag">Gets or sets the value indicating that rounding in report should be turned off.</param>
        /// <param name="reportParamsTimeEntryFilter">Gets or sets the string that will be found in time entry descriptions.</param>
        /// <param name="reportParamsChartValue">Gets or sets the column that will be shown on chart.</param>
        /// <param name="reportParamsAccountId">Gets or sets the account identifier.</param>
        /// <param name="reportParamsStartDate">Gets or sets report start date.</param>
        /// <param name="reportParamsEndDate">Gets or sets report end date.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public Task<ObservableCollection<DetailedReportRow>> GetDetailedReportAsync(
            IEnumerable<int> projectListReportFilter,
            IEnumerable<int> tagListReportFilter,
            IEnumerable<string> groupColumnNamesReportFilter,
            bool? activeProjectsOnlyReportFlag,
            bool? noRoundingReportFlag,
            string reportParamsTimeEntryFilter,
            string reportParamsChartValue,
            int? reportParamsAccountId,
            DateTime? reportParamsStartDate,
            DateTime? reportParamsEndDate)
        {
            return GetDetailedReportAsync(projectListReportFilter, tagListReportFilter,
                groupColumnNamesReportFilter, activeProjectsOnlyReportFlag, noRoundingReportFlag,
                reportParamsTimeEntryFilter, reportParamsChartValue,
                reportParamsAccountId, reportParamsStartDate, reportParamsEndDate, CancellationToken.None);
        }

        /// <summary>Gets the detailed report.</summary>
        /// <param name="projectListReportFilter">Gets or sets project list for report filter.</param>
        /// <param name="tagListReportFilter">Gets or sets tag list for report filter.</param>
        /// <param name="groupColumnNamesReportFilter">Gets or sets the group column names.</param>
        /// <param name="activeProjectsOnlyReportFlag">Gets or sets the value indicating that only active projects should be returned.</param>
        /// <param name="noRoundingReportFlag">Gets or sets the value indicating that rounding in report should be turned off.</param>
        /// <param name="reportParamsTimeEntryFilter">Gets or sets the string that will be found in time entry descriptions.</param>
        /// <param name="reportParamsChartValue">Gets or sets the column that will be shown on chart.</param>
        /// <param name="reportParamsAccountId">Gets or sets the account identifier.</param>
        /// <param name="reportParamsStartDate">Gets or sets report start date.</param>
        /// <param name="reportParamsEndDate">Gets or sets report end date.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task<ObservableCollection<DetailedReportRow>> GetDetailedReportAsync(
            IEnumerable<int> projectListReportFilter,
            IEnumerable<int> tagListReportFilter,
            IEnumerable<string> groupColumnNamesReportFilter,
            bool? activeProjectsOnlyReportFlag,
            bool? noRoundingReportFlag,
            string reportParamsTimeEntryFilter,
            string reportParamsChartValue,
            int? reportParamsAccountId,
            DateTime? reportParamsStartDate,
            DateTime? reportParamsEndDate,
            CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append("/api/reports/detailed?");
            if (projectListReportFilter != null)
                foreach (var item in projectListReportFilter)
                    urlBuilder.Append("reportParams.projectList=")
                        .Append(Uri.EscapeDataString(Convert.ToString(item, CultureInfo.InvariantCulture))).Append("&");
            if (tagListReportFilter != null)
                foreach (var item in tagListReportFilter)
                    urlBuilder.Append("reportParams.tagList=")
                        .Append(Uri.EscapeDataString(Convert.ToString(item, CultureInfo.InvariantCulture))).Append("&");
            if (groupColumnNamesReportFilter != null)
                foreach (var item in groupColumnNamesReportFilter)
                    urlBuilder.Append("reportParams.groupColumnNames=")
                        .Append(Uri.EscapeDataString(Convert.ToString(item, CultureInfo.InvariantCulture))).Append("&");
            if (activeProjectsOnlyReportFlag != null)
                urlBuilder.Append("reportParams.activeProjectsOnly=")
                    .Append(Uri.EscapeDataString(Convert.ToString(activeProjectsOnlyReportFlag.Value,
                        CultureInfo.InvariantCulture))).Append("&");
            if (noRoundingReportFlag != null)
                urlBuilder.Append("reportParams.noRounding=")
                    .Append(Uri.EscapeDataString(
                        Convert.ToString(noRoundingReportFlag.Value, CultureInfo.InvariantCulture))).Append("&");
            if (reportParamsTimeEntryFilter != null)
                urlBuilder.Append("reportParams.timeEntryFilter=")
                    .Append(Uri.EscapeDataString(
                        Convert.ToString(reportParamsTimeEntryFilter, CultureInfo.InvariantCulture))).Append("&");
            if (reportParamsChartValue != null)
                urlBuilder.Append("reportParams.chartValue=")
                    .Append(
                        Uri.EscapeDataString(Convert.ToString(reportParamsChartValue, CultureInfo.InvariantCulture)))
                    .Append("&");
            if (reportParamsAccountId != null)
                urlBuilder.Append("reportParams.accountId=")
                    .Append(Uri.EscapeDataString(
                        Convert.ToString(reportParamsAccountId.Value, CultureInfo.InvariantCulture))).Append("&");
            if (reportParamsStartDate != null)
                urlBuilder.Append("reportParams.startDate=")
                    .Append(Uri.EscapeDataString(
                        reportParamsStartDate.Value.ToString("s", CultureInfo.InvariantCulture))).Append("&");
            if (reportParamsEndDate != null)
                urlBuilder.Append("reportParams.endDate=")
                    .Append(Uri.EscapeDataString(reportParamsEndDate.Value.ToString("s", CultureInfo.InvariantCulture)))
                    .Append("&");
            urlBuilder.Length--;

            using (var client = PrepareHttpClient())
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Method = new HttpMethod("GET");
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client, request, urlBuilder);
                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.Relative);
                    PrepareRequest(client, request, url);

                    using (var response = await client
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                        .ConfigureAwait(false))
                    {
                        var headers = response.Headers.ToDictionary(h => h.Key, h => h.Value);
                        foreach (var item in response.Content.Headers)
                            headers[item.Key] = item.Value;

                        ProcessResponse(client, response);

                        if (!response.IsSuccessStatusCode)
                            throw new SwaggerException(
                                "The HTTP status code of the response was not expected (" + (int) response.StatusCode +
                                ").", response.StatusCode.ToString(),
                                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
                                , headers, null);

                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        try
                        {
                            var result =
                                JsonConvert.DeserializeObject<ObservableCollection<DetailedReportRow>>(responseData,
                                    _settings.Value);
                            return result;
                        }
                        catch (Exception exception)
                        {
                            throw new SwaggerException("Could not deserialize the response body.", response.StatusCode.ToString(),
                                responseData, headers, exception);
                        }
                    }
                }
            }
        }

    }

}