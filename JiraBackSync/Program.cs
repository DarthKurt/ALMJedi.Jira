using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Atlassian.Jira;
using JiraBackSync.Data;
using JiraBackSync.Properties;
using Newtonsoft.Json;

namespace JiraBackSync
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                var projectList = new List<int>
                {
                    0, // None
                    Settings.Default.TMetricProject
                };

                var startOfWeek = StartOfWeek(DateTime.Today.AddDays(Settings.Default.WeekOffset * 7),
                    CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);

                var endOfWeek = EndOfWeek(DateTime.Today.AddDays(Settings.Default.WeekOffset * 7),
                    CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);

                Console.WriteLine("TMetric password:");
                var loginClient = new LoginClient
                {
                    Password = ExtendedConsole.ReadPassword()
                };
                

                var apiClient = new ReportDetailedClient
                {
                    ApiKey = loginClient.GetApiKeyAsync(CancellationToken.None).GetAwaiter().GetResult()
                };

                var tmetricLogs = apiClient.GetDetailedReportAsync(projectList, null, new List<string>(), true, true, null, null,
                    Settings.Default.TMetricAccountId, startOfWeek, endOfWeek).GetAwaiter().GetResult();

                var aggregated = tmetricLogs.GroupBy(r => new {r.Day, r.IssueId})
                    .Select(DetailedReportRowAggregatedTimeEntryAdapter.CreateLogEntry)
                    .Where(c => c.IssueKey != null)
                    .ToList();

                var issueKeys = aggregated.Select(e => e.IssueKey).Distinct();

                Console.WriteLine($"Reported entries found: {tmetricLogs.Count}");
                Console.WriteLine($"Aggregated entries found: {aggregated.Count}");
                var result = ProcessIssuesAsync(issueKeys, aggregated).GetAwaiter().GetResult();

                if (result == null)
                {
                    Console.WriteLine("No issues processed.");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine($"Issues updated: {result.Item1}");
                Console.WriteLine($"Time reported to Jira: {result.Item2}");
                Console.WriteLine($"Time removed from Jira: {result.Item3}");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        private static DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            var diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }
            return dt.AddDays(-1 * diff).Date;
        }

        private static DateTime EndOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            var nextWeekDate = dt.AddDays(7);
            var nextWeekStartDate = StartOfWeek(nextWeekDate, startOfWeek);

            return nextWeekStartDate.AddTicks(-1);
        }

        private static async Task<Tuple<int, TimeSpan, TimeSpan>> ProcessIssuesAsync(
            IEnumerable<ComparableString> issuesKeys, IEnumerable<AggregatedTimeEntry> logs)
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var settings = new JiraRestClientSettings();

#if DEBUG
            settings.EnableRequestTrace = true;
            settings.JsonSerializerSettings.TraceWriter = new VsTraceWriter();
#endif
            Console.WriteLine("Jira password:");
            var jira = Jira.CreateRestClient(
                "https://owl.cbsi.com/jira",
                Settings.Default.JiraUserName,
                ExtendedConsole.ReadPassword(),
                settings);

#if DEBUG
            jira.Debug = true;
#endif

            
            try
            {
                //var issues = await GetIssuesAsync(issuesKeys, jira).ConfigureAwait(false);
                return await UpdateLogsAsync(issuesKeys, logs, jira).ConfigureAwait(false);
            }
            catch(JsonReaderException jre)
            {
                Console.WriteLine(jre);

#if DEBUG
                Debug.WriteLine(jre);
#endif
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
#if DEBUG
                Debug.WriteLine(e);
#endif
                return null;
            }
        }

        //private static Task<IDictionary<string,Issue>> GetIssuesAsync(IEnumerable<ComparableString> issues, Jira jira)
        //{
        //    return jira.Issues.GetIssuesAsync(issues.Select(k => k.Value));
        //}

        private static async Task<Tuple<int, TimeSpan, TimeSpan>> UpdateLogsAsync(IEnumerable<ComparableString> issues, IEnumerable<AggregatedTimeEntry> logs, Jira jira)
        {
            //var issueList = issues.Values.Where(i => i.Labels.Contains("SED-Backlog") && i.Labels.Contains("SED-PAX")).ToList();
            var keys = issues as IList<ComparableString> ?? issues.ToList();

            var issueCount = 0;
            var timeAddedCount = new TimeSpan();
            long timeDeletedCount = 0;

            foreach (var log in logs)
            {
                if (log.TimeLog.TotalHours > 20)
                {
                    throw new InvalidOperationException("Log could not be more 20 hours per day.");
                }

                //var issue = issueList.FirstOrDefault(i => i.Key.Equals(log.IssueKey));
                var issueKey = keys.FirstOrDefault(k => k.Equals(log.IssueKey))?.Value;

                if (issueKey == null)
                    continue;

                var worklogs = await jira.Issues.GetWorklogsAsync(issueKey).ConfigureAwait(false);

                var neededLogs = worklogs.Where(wl =>
                    wl.StartDate.HasValue
                    && wl.Author.Equals(Settings.Default.JiraUserName)
                    && wl.StartDate.Value.Date.Equals(log.StartDate.Date)).ToList();

                if (neededLogs.Count > 1)
                    throw new InvalidOperationException("There should be the only one log per day.");

                var ewl = neededLogs.FirstOrDefault();

                var logString = new StringBuilder(log.TimeLog.ToString(@"h'h'"));

                if (log.TimeLog.Minutes > 0)
                    logString.Append($" {log.TimeLog.Minutes}m");

                var newWorklog = new Worklog(logString.ToString(), log.StartDate.ToLocalTime(), log.LogComments.Value);

                await jira.Issues.AddWorklogAsync(issueKey, newWorklog)
                    .ConfigureAwait(false);
                issueCount++;
                timeAddedCount = timeAddedCount.Add(log.TimeLog);

                if (ewl == null)
                    continue;

                await jira.Issues.DeleteWorklogAsync(issueKey, ewl.Id)
                    .ConfigureAwait(false);
                timeDeletedCount += ewl.TimeSpentInSeconds;
            }

            return new Tuple<int,TimeSpan,TimeSpan>(issueCount, timeAddedCount, TimeSpan.FromSeconds(timeDeletedCount));
        }
    }
}