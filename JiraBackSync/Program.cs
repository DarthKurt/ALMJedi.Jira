using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Atlassian.Jira;
using JiraBackSync.Data;
using JiraBackSync.Properties;

namespace JiraBackSync
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                const int activeAccountId = 10880;
                var projectList = new List<int>
                {
                    0,
                    16494
                };

                var startOfWeek = StartOfWeek(DateTime.Today,
                    CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);

                var endOfWeek = EndOfWeek(DateTime.Today,
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
                    activeAccountId, startOfWeek, endOfWeek).GetAwaiter().GetResult();

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
                var issues = await GetIssuesAsync(issuesKeys, jira).ConfigureAwait(false);
                return await UpdateLogsAsync(issues, logs).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private static Task<IDictionary<string,Issue>> GetIssuesAsync(IEnumerable<ComparableString> issues, Jira jira)
        {
            return jira.Issues.GetIssuesAsync(issues.Select(k => k.Value));
        }

        private static async Task<Tuple<int, TimeSpan, TimeSpan>> UpdateLogsAsync(IDictionary<string, Issue> issues, IEnumerable<AggregatedTimeEntry> logs)
        {
            var issueList = issues.Values.Where(i => i.Labels.Contains("SED-Backlog") && i.Labels.Contains("SED-PAX")).ToList();

            var issueCount = 0;
            var timeAddedCount = new TimeSpan();
            long timeDeletedCount = 0;

            foreach (var log in logs)
            {
                if (log.TimeLog.TotalHours > 20)
                {
                    throw new InvalidOperationException("Log could not be more 20 hours per day.");
                }

                var issue = issueList.FirstOrDefault(i => i.Key.Equals(log.IssueKey));

                if (issue == null)
                    continue;

                var worklogs = await issue.GetWorklogsAsync().ConfigureAwait(false);

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

                var newWorklog = new Worklog(logString.ToString(), log.StartDate.ToLocalTime());

                await issue.AddWorklogAsync(newWorklog)
                    .ConfigureAwait(false);
                issueCount++;
                timeAddedCount = timeAddedCount.Add(log.TimeLog);

                if (ewl == null)
                    continue;

                await issue.DeleteWorklogAsync(ewl)
                    .ConfigureAwait(false);
                timeDeletedCount += ewl.TimeSpentInSeconds;
            }

            return new Tuple<int,TimeSpan,TimeSpan>(issueCount, timeAddedCount, TimeSpan.FromSeconds(timeDeletedCount));
        }
    }
}