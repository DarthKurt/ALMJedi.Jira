using System;
using System.CodeDom.Compiler;
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
using JiraBackSync.Data;
using Newtonsoft.Json;

namespace JiraBackSync
{
    [GeneratedCode("NSwag", "11.4.3.0")]
    public sealed class ReportDetailedClient : BaseTmetricApiClient
    {
        private readonly Lazy<JsonSerializerSettings> _settings;

        public ReportDetailedClient()
        {
            _settings = new Lazy<JsonSerializerSettings>(() =>
            {
                var settings = new JsonSerializerSettings();
                UpdateJsonSerializerSettings(settings);
                return settings;
            });
        }

        public CookieCollection ApiKey { get; set; }

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
            if (ApiKey != null && ApiKey.Count > 0)
                cookieContainer.Add(ApiKey);

            return client;
        }

        /// <summary>Gets the detailed report as CSV.</summary>
        /// <param name="reportParamsProjectList">Gets or sets project list for report filter.</param>
        /// <param name="reportParamsClientList">Gets or sets cluent list for report filter.</param>
        /// <param name="reportParamsTagList">Gets or sets tag list for report filter.</param>
        /// <param name="reportParamsGroupColumnNames">Gets or sets the group column names.</param>
        /// <param name="reportParamsActiveProjectsOnly">Gets or sets the value indicating that only active projects should be returned.</param>
        /// <param name="reportParamsBillable">Gets or sets the value indicating which tasks should be returned: false - non-billable, true - billable, null - both.</param>
        /// <param name="reportParamsInvoiced">Gets or sets the value indicating which tasks should be returned: false - ununvoiced, true - invoiced, null - both.</param>
        /// <param name="reportParamsNoRounding">Gets or sets the value indicating that rounding in report should be turned off.</param>
        /// <param name="reportParamsTimeEntryFilter">Gets or sets the string that will be found in time entry descriptions.</param>
        /// <param name="reportParamsChartValue">Gets or sets the column that will be shown on chart.</param>
        /// <param name="reportParamsAccountId">Gets or sets the account identifier.</param>
        /// <param name="reportParamsStartDate">Gets or sets report start date.</param>
        /// <param name="reportParamsEndDate">Gets or sets report end date.</param>
        /// <param name="reportParamsProfileList">Gets or sets profile list for report filter.</param>
        /// <param name="reportParamsGroupList">Gets or sets group list for report filter.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public Task<object> GetDetailedCsvAsync(IEnumerable<int> reportParamsProjectList, IEnumerable<int> reportParamsClientList, IEnumerable<int> reportParamsTagList, IEnumerable<string> reportParamsGroupColumnNames, bool? reportParamsActiveProjectsOnly, bool? reportParamsBillable, bool? reportParamsInvoiced, bool? reportParamsNoRounding, string reportParamsTimeEntryFilter, string reportParamsChartValue, int? reportParamsAccountId, DateTime? reportParamsStartDate, DateTime? reportParamsEndDate, IEnumerable<int> reportParamsProfileList, IEnumerable<int> reportParamsGroupList)
        {
            return GetDetailedCsvAsync(reportParamsProjectList, reportParamsClientList, reportParamsTagList, reportParamsGroupColumnNames, reportParamsActiveProjectsOnly, reportParamsBillable, reportParamsInvoiced, reportParamsNoRounding, reportParamsTimeEntryFilter, reportParamsChartValue, reportParamsAccountId, reportParamsStartDate, reportParamsEndDate, reportParamsProfileList, reportParamsGroupList, CancellationToken.None);
        }

        /// <summary>Gets the detailed report as CSV.</summary>
        /// <param name="reportParamsProjectList">Gets or sets project list for report filter.</param>
        /// <param name="reportParamsClientList">Gets or sets cluent list for report filter.</param>
        /// <param name="reportParamsTagList">Gets or sets tag list for report filter.</param>
        /// <param name="reportParamsGroupColumnNames">Gets or sets the group column names.</param>
        /// <param name="reportParamsActiveProjectsOnly">Gets or sets the value indicating that only active projects should be returned.</param>
        /// <param name="reportParamsBillable">Gets or sets the value indicating which tasks should be returned: false - non-billable, true - billable, null - both.</param>
        /// <param name="reportParamsInvoiced">Gets or sets the value indicating which tasks should be returned: false - ununvoiced, true - invoiced, null - both.</param>
        /// <param name="reportParamsNoRounding">Gets or sets the value indicating that rounding in report should be turned off.</param>
        /// <param name="reportParamsTimeEntryFilter">Gets or sets the string that will be found in time entry descriptions.</param>
        /// <param name="reportParamsChartValue">Gets or sets the column that will be shown on chart.</param>
        /// <param name="reportParamsAccountId">Gets or sets the account identifier.</param>
        /// <param name="reportParamsStartDate">Gets or sets report start date.</param>
        /// <param name="reportParamsEndDate">Gets or sets report end date.</param>
        /// <param name="reportParamsProfileList">Gets or sets profile list for report filter.</param>
        /// <param name="reportParamsGroupList">Gets or sets group list for report filter.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task<object> GetDetailedCsvAsync(IEnumerable<int> reportParamsProjectList, IEnumerable<int> reportParamsClientList, IEnumerable<int> reportParamsTagList, IEnumerable<string> reportParamsGroupColumnNames, bool? reportParamsActiveProjectsOnly, bool? reportParamsBillable, bool? reportParamsInvoiced, bool? reportParamsNoRounding, string reportParamsTimeEntryFilter, string reportParamsChartValue, int? reportParamsAccountId, DateTime? reportParamsStartDate, DateTime? reportParamsEndDate, IEnumerable<int> reportParamsProfileList, IEnumerable<int> reportParamsGroupList, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl).Append("/api/reports/detailed/csv?");
            if (reportParamsProjectList != null) foreach (var item in reportParamsProjectList) { urlBuilder.Append("reportParams.projectList=").Append(Uri.EscapeDataString(Convert.ToString(item, CultureInfo.InvariantCulture))).Append("&"); }
            if (reportParamsClientList != null) foreach (var item in reportParamsClientList) { urlBuilder.Append("reportParams.clientList=").Append(Uri.EscapeDataString(Convert.ToString(item, CultureInfo.InvariantCulture))).Append("&"); }
            if (reportParamsTagList != null) foreach (var item in reportParamsTagList) { urlBuilder.Append("reportParams.tagList=").Append(Uri.EscapeDataString(Convert.ToString(item, CultureInfo.InvariantCulture))).Append("&"); }
            if (reportParamsGroupColumnNames != null) foreach (var item in reportParamsGroupColumnNames) { urlBuilder.Append("reportParams.groupColumnNames=").Append(Uri.EscapeDataString(Convert.ToString(item, CultureInfo.InvariantCulture))).Append("&"); }
            if (reportParamsActiveProjectsOnly != null) urlBuilder.Append("reportParams.activeProjectsOnly=").Append(Uri.EscapeDataString(Convert.ToString(reportParamsActiveProjectsOnly.Value, CultureInfo.InvariantCulture))).Append("&");
            if (reportParamsBillable != null) urlBuilder.Append("reportParams.billable=").Append(Uri.EscapeDataString(Convert.ToString(reportParamsBillable.Value, CultureInfo.InvariantCulture))).Append("&");
            if (reportParamsInvoiced != null) urlBuilder.Append("reportParams.invoiced=").Append(Uri.EscapeDataString(Convert.ToString(reportParamsInvoiced.Value, CultureInfo.InvariantCulture))).Append("&");
            if (reportParamsNoRounding != null) urlBuilder.Append("reportParams.noRounding=").Append(Uri.EscapeDataString(Convert.ToString(reportParamsNoRounding.Value, CultureInfo.InvariantCulture))).Append("&");
            if (reportParamsTimeEntryFilter != null) urlBuilder.Append("reportParams.timeEntryFilter=").Append(Uri.EscapeDataString(Convert.ToString(reportParamsTimeEntryFilter, CultureInfo.InvariantCulture))).Append("&");
            if (reportParamsChartValue != null) urlBuilder.Append("reportParams.chartValue=").Append(Uri.EscapeDataString(Convert.ToString(reportParamsChartValue, CultureInfo.InvariantCulture))).Append("&");
            if (reportParamsAccountId != null) urlBuilder.Append("reportParams.accountId=").Append(Uri.EscapeDataString(Convert.ToString(reportParamsAccountId.Value, CultureInfo.InvariantCulture))).Append("&");
            if (reportParamsStartDate != null) urlBuilder.Append("reportParams.startDate=").Append(Uri.EscapeDataString(reportParamsStartDate.Value.ToString("s", CultureInfo.InvariantCulture))).Append("&");
            if (reportParamsEndDate != null) urlBuilder.Append("reportParams.endDate=").Append(Uri.EscapeDataString(reportParamsEndDate.Value.ToString("s", CultureInfo.InvariantCulture))).Append("&");
            if (reportParamsProfileList != null) foreach (var item in reportParamsProfileList) { urlBuilder.Append("reportParams.profileList=").Append(Uri.EscapeDataString(Convert.ToString(item, CultureInfo.InvariantCulture))).Append("&"); }
            if (reportParamsGroupList != null) foreach (var item in reportParamsGroupList) { urlBuilder.Append("reportParams.groupList=").Append(Uri.EscapeDataString(Convert.ToString(item, CultureInfo.InvariantCulture))).Append("&"); }
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
                client?.Dispose();
            }
        }

        /// <summary>Gets the detailed report as PDF.</summary>
        /// <param name="reportParamsProjectList">Gets or sets project list for report filter.</param>
        /// <param name="reportParamsClientList">Gets or sets cluent list for report filter.</param>
        /// <param name="reportParamsTagList">Gets or sets tag list for report filter.</param>
        /// <param name="reportParamsGroupColumnNames">Gets or sets the group column names.</param>
        /// <param name="reportParamsActiveProjectsOnly">Gets or sets the value indicating that only active projects should be returned.</param>
        /// <param name="reportParamsBillable">Gets or sets the value indicating which tasks should be returned: false - non-billable, true - billable, null - both.</param>
        /// <param name="reportParamsInvoiced">Gets or sets the value indicating which tasks should be returned: false - ununvoiced, true - invoiced, null - both.</param>
        /// <param name="reportParamsNoRounding">Gets or sets the value indicating that rounding in report should be turned off.</param>
        /// <param name="reportParamsTimeEntryFilter">Gets or sets the string that will be found in time entry descriptions.</param>
        /// <param name="reportParamsChartValue">Gets or sets the column that will be shown on chart.</param>
        /// <param name="reportParamsAccountId">Gets or sets the account identifier.</param>
        /// <param name="reportParamsStartDate">Gets or sets report start date.</param>
        /// <param name="reportParamsEndDate">Gets or sets report end date.</param>
        /// <param name="reportParamsProfileList">Gets or sets profile list for report filter.</param>
        /// <param name="reportParamsGroupList">Gets or sets group list for report filter.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public Task<object> GetDetailedPdfAsync(IEnumerable<int> reportParamsProjectList, IEnumerable<int> reportParamsClientList, IEnumerable<int> reportParamsTagList, IEnumerable<string> reportParamsGroupColumnNames, bool? reportParamsActiveProjectsOnly, bool? reportParamsBillable, bool? reportParamsInvoiced, bool? reportParamsNoRounding, string reportParamsTimeEntryFilter, string reportParamsChartValue, int? reportParamsAccountId, DateTime? reportParamsStartDate, DateTime? reportParamsEndDate, IEnumerable<int> reportParamsProfileList, IEnumerable<int> reportParamsGroupList)
        {
            return GetDetailedPdfAsync(reportParamsProjectList, reportParamsClientList, reportParamsTagList, reportParamsGroupColumnNames, reportParamsActiveProjectsOnly, reportParamsBillable, reportParamsInvoiced, reportParamsNoRounding, reportParamsTimeEntryFilter, reportParamsChartValue, reportParamsAccountId, reportParamsStartDate, reportParamsEndDate, reportParamsProfileList, reportParamsGroupList, CancellationToken.None);
        }

        /// <summary>Gets the detailed report as PDF.</summary>
        /// <param name="reportParamsProjectList">Gets or sets project list for report filter.</param>
        /// <param name="reportParamsClientList">Gets or sets cluent list for report filter.</param>
        /// <param name="reportParamsTagList">Gets or sets tag list for report filter.</param>
        /// <param name="reportParamsGroupColumnNames">Gets or sets the group column names.</param>
        /// <param name="reportParamsActiveProjectsOnly">Gets or sets the value indicating that only active projects should be returned.</param>
        /// <param name="reportParamsBillable">Gets or sets the value indicating which tasks should be returned: false - non-billable, true - billable, null - both.</param>
        /// <param name="reportParamsInvoiced">Gets or sets the value indicating which tasks should be returned: false - ununvoiced, true - invoiced, null - both.</param>
        /// <param name="reportParamsNoRounding">Gets or sets the value indicating that rounding in report should be turned off.</param>
        /// <param name="reportParamsTimeEntryFilter">Gets or sets the string that will be found in time entry descriptions.</param>
        /// <param name="reportParamsChartValue">Gets or sets the column that will be shown on chart.</param>
        /// <param name="reportParamsAccountId">Gets or sets the account identifier.</param>
        /// <param name="reportParamsStartDate">Gets or sets report start date.</param>
        /// <param name="reportParamsEndDate">Gets or sets report end date.</param>
        /// <param name="reportParamsProfileList">Gets or sets profile list for report filter.</param>
        /// <param name="reportParamsGroupList">Gets or sets group list for report filter.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task<object> GetDetailedPdfAsync(IEnumerable<int> reportParamsProjectList, IEnumerable<int> reportParamsClientList, IEnumerable<int> reportParamsTagList, IEnumerable<string> reportParamsGroupColumnNames, bool? reportParamsActiveProjectsOnly, bool? reportParamsBillable, bool? reportParamsInvoiced, bool? reportParamsNoRounding, string reportParamsTimeEntryFilter, string reportParamsChartValue, int? reportParamsAccountId, DateTime? reportParamsStartDate, DateTime? reportParamsEndDate, IEnumerable<int> reportParamsProfileList, IEnumerable<int> reportParamsGroupList, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl).Append("/api/reports/detailed/pdf?");
            if (reportParamsProjectList != null) foreach (var item in reportParamsProjectList) { urlBuilder.Append("reportParams.projectList=").Append(Uri.EscapeDataString(Convert.ToString(item, CultureInfo.InvariantCulture))).Append("&"); }
            if (reportParamsClientList != null) foreach (var item in reportParamsClientList) { urlBuilder.Append("reportParams.clientList=").Append(Uri.EscapeDataString(Convert.ToString(item, CultureInfo.InvariantCulture))).Append("&"); }
            if (reportParamsTagList != null) foreach (var item in reportParamsTagList) { urlBuilder.Append("reportParams.tagList=").Append(Uri.EscapeDataString(Convert.ToString(item, CultureInfo.InvariantCulture))).Append("&"); }
            if (reportParamsGroupColumnNames != null) foreach (var item in reportParamsGroupColumnNames) { urlBuilder.Append("reportParams.groupColumnNames=").Append(Uri.EscapeDataString(Convert.ToString(item, CultureInfo.InvariantCulture))).Append("&"); }
            if (reportParamsActiveProjectsOnly != null) urlBuilder.Append("reportParams.activeProjectsOnly=").Append(Uri.EscapeDataString(Convert.ToString(reportParamsActiveProjectsOnly.Value, CultureInfo.InvariantCulture))).Append("&");
            if (reportParamsBillable != null) urlBuilder.Append("reportParams.billable=").Append(Uri.EscapeDataString(Convert.ToString(reportParamsBillable.Value, CultureInfo.InvariantCulture))).Append("&");
            if (reportParamsInvoiced != null) urlBuilder.Append("reportParams.invoiced=").Append(Uri.EscapeDataString(Convert.ToString(reportParamsInvoiced.Value, CultureInfo.InvariantCulture))).Append("&");
            if (reportParamsNoRounding != null) urlBuilder.Append("reportParams.noRounding=").Append(Uri.EscapeDataString(Convert.ToString(reportParamsNoRounding.Value, CultureInfo.InvariantCulture))).Append("&");
            if (reportParamsTimeEntryFilter != null) urlBuilder.Append("reportParams.timeEntryFilter=").Append(Uri.EscapeDataString(Convert.ToString(reportParamsTimeEntryFilter, CultureInfo.InvariantCulture))).Append("&");
            if (reportParamsChartValue != null) urlBuilder.Append("reportParams.chartValue=").Append(Uri.EscapeDataString(Convert.ToString(reportParamsChartValue, CultureInfo.InvariantCulture))).Append("&");
            if (reportParamsAccountId != null) urlBuilder.Append("reportParams.accountId=").Append(Uri.EscapeDataString(Convert.ToString(reportParamsAccountId.Value, CultureInfo.InvariantCulture))).Append("&");
            if (reportParamsStartDate != null) urlBuilder.Append("reportParams.startDate=").Append(Uri.EscapeDataString(reportParamsStartDate.Value.ToString("s", CultureInfo.InvariantCulture))).Append("&");
            if (reportParamsEndDate != null) urlBuilder.Append("reportParams.endDate=").Append(Uri.EscapeDataString(reportParamsEndDate.Value.ToString("s", CultureInfo.InvariantCulture))).Append("&");
            if (reportParamsProfileList != null) foreach (var item in reportParamsProfileList) { urlBuilder.Append("reportParams.profileList=").Append(Uri.EscapeDataString(Convert.ToString(item, CultureInfo.InvariantCulture))).Append("&"); }
            if (reportParamsGroupList != null) foreach (var item in reportParamsGroupList) { urlBuilder.Append("reportParams.groupList=").Append(Uri.EscapeDataString(Convert.ToString(item, CultureInfo.InvariantCulture))).Append("&"); }
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
                client?.Dispose();
            }
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