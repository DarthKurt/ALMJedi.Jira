﻿using System;
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
    public class ReportProjectsClient
    {
        private readonly Lazy<JsonSerializerSettings> _settings;

        public ReportProjectsClient()
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

        /// <summary>Gets the summary projects report as CSV.</summary>
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
        public Task<object> GetSummaryProjectsCsvAsync(IEnumerable<int> reportParamsProjectList, IEnumerable<int> reportParamsClientList, IEnumerable<int> reportParamsTagList, IEnumerable<string> reportParamsGroupColumnNames, bool? reportParamsActiveProjectsOnly, bool? reportParamsBillable, bool? reportParamsInvoiced, bool? reportParamsNoRounding, string reportParamsTimeEntryFilter, string reportParamsChartValue, int? reportParamsAccountId, DateTime? reportParamsStartDate, DateTime? reportParamsEndDate, IEnumerable<int> reportParamsProfileList, IEnumerable<int> reportParamsGroupList)
        {
            return GetSummaryProjectsCsvAsync(reportParamsProjectList, reportParamsClientList, reportParamsTagList, reportParamsGroupColumnNames, reportParamsActiveProjectsOnly, reportParamsBillable, reportParamsInvoiced, reportParamsNoRounding, reportParamsTimeEntryFilter, reportParamsChartValue, reportParamsAccountId, reportParamsStartDate, reportParamsEndDate, reportParamsProfileList, reportParamsGroupList, CancellationToken.None);
        }

        /// <summary>Gets the summary projects report as CSV.</summary>
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
        public async Task<object> GetSummaryProjectsCsvAsync(IEnumerable<int> reportParamsProjectList, IEnumerable<int> reportParamsClientList, IEnumerable<int> reportParamsTagList, IEnumerable<string> reportParamsGroupColumnNames, bool? reportParamsActiveProjectsOnly, bool? reportParamsBillable, bool? reportParamsInvoiced, bool? reportParamsNoRounding, string reportParamsTimeEntryFilter, string reportParamsChartValue, int? reportParamsAccountId, DateTime? reportParamsStartDate, DateTime? reportParamsEndDate, IEnumerable<int> reportParamsProfileList, IEnumerable<int> reportParamsGroupList, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl).Append("/api/reports/summary/projects/csv?");
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

        /// <summary>Gets the summary projects report as PDF.</summary>
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
        public Task<object> GetSummaryProjectsPdfAsync(IEnumerable<int> reportParamsProjectList, IEnumerable<int> reportParamsClientList, IEnumerable<int> reportParamsTagList, IEnumerable<string> reportParamsGroupColumnNames, bool? reportParamsActiveProjectsOnly, bool? reportParamsBillable, bool? reportParamsInvoiced, bool? reportParamsNoRounding, string reportParamsTimeEntryFilter, string reportParamsChartValue, int? reportParamsAccountId, DateTime? reportParamsStartDate, DateTime? reportParamsEndDate, IEnumerable<int> reportParamsProfileList, IEnumerable<int> reportParamsGroupList)
        {
            return GetSummaryProjectsPdfAsync(reportParamsProjectList, reportParamsClientList, reportParamsTagList, reportParamsGroupColumnNames, reportParamsActiveProjectsOnly, reportParamsBillable, reportParamsInvoiced, reportParamsNoRounding, reportParamsTimeEntryFilter, reportParamsChartValue, reportParamsAccountId, reportParamsStartDate, reportParamsEndDate, reportParamsProfileList, reportParamsGroupList, CancellationToken.None);
        }

        /// <summary>Gets the summary projects report as PDF.</summary>
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
        public async Task<object> GetSummaryProjectsPdfAsync(IEnumerable<int> reportParamsProjectList, IEnumerable<int> reportParamsClientList, IEnumerable<int> reportParamsTagList, IEnumerable<string> reportParamsGroupColumnNames, bool? reportParamsActiveProjectsOnly, bool? reportParamsBillable, bool? reportParamsInvoiced, bool? reportParamsNoRounding, string reportParamsTimeEntryFilter, string reportParamsChartValue, int? reportParamsAccountId, DateTime? reportParamsStartDate, DateTime? reportParamsEndDate, IEnumerable<int> reportParamsProfileList, IEnumerable<int> reportParamsGroupList, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl).Append("/api/reports/summary/projects/pdf?");
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

        /// <summary>Gets the summary projects report.</summary>
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
        public Task<ObservableCollection<SummaryProjectReportRow>> GetSummaryProjectsReportAsync(IEnumerable<int> reportParamsProjectList, IEnumerable<int> reportParamsClientList, IEnumerable<int> reportParamsTagList, IEnumerable<string> reportParamsGroupColumnNames, bool? reportParamsActiveProjectsOnly, bool? reportParamsBillable, bool? reportParamsInvoiced, bool? reportParamsNoRounding, string reportParamsTimeEntryFilter, string reportParamsChartValue, int? reportParamsAccountId, DateTime? reportParamsStartDate, DateTime? reportParamsEndDate, IEnumerable<int> reportParamsProfileList, IEnumerable<int> reportParamsGroupList)
        {
            return GetSummaryProjectsReportAsync(reportParamsProjectList, reportParamsClientList, reportParamsTagList, reportParamsGroupColumnNames, reportParamsActiveProjectsOnly, reportParamsBillable, reportParamsInvoiced, reportParamsNoRounding, reportParamsTimeEntryFilter, reportParamsChartValue, reportParamsAccountId, reportParamsStartDate, reportParamsEndDate, reportParamsProfileList, reportParamsGroupList, CancellationToken.None);
        }

        /// <summary>Gets the summary projects report.</summary>
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
        public async Task<ObservableCollection<SummaryProjectReportRow>> GetSummaryProjectsReportAsync(IEnumerable<int> reportParamsProjectList, IEnumerable<int> reportParamsClientList, IEnumerable<int> reportParamsTagList, IEnumerable<string> reportParamsGroupColumnNames, bool? reportParamsActiveProjectsOnly, bool? reportParamsBillable, bool? reportParamsInvoiced, bool? reportParamsNoRounding, string reportParamsTimeEntryFilter, string reportParamsChartValue, int? reportParamsAccountId, DateTime? reportParamsStartDate, DateTime? reportParamsEndDate, IEnumerable<int> reportParamsProfileList, IEnumerable<int> reportParamsGroupList, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl).Append("/api/reports/summary/projects?");
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
                            var result = default(ObservableCollection<SummaryProjectReportRow>);
                            try
                            {
                                result = JsonConvert.DeserializeObject<ObservableCollection<SummaryProjectReportRow>>(responseData, _settings.Value);
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

                        return default(ObservableCollection<SummaryProjectReportRow>);
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