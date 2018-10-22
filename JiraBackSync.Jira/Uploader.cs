using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Atlassian.Jira;
using JiraBackSync.Core.Data;
using JiraBackSync.Core.Utils;
using JiraBackSync.Jira.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace JiraBackSync.Jira
{
    public class Uploader: IUploader
    {
        private readonly ILoggerFactory _loggingFactory;
        private readonly UploaderServiceOptions _config;

        public Uploader(ILoggerFactory loggingFactory, IOptions<UploaderServiceOptions> config)
        {
            _loggingFactory = loggingFactory;
            _config = config.Value;
        }

        public void Upload(string pwd, IEnumerable<string> issues, IEnumerable<AggregatedTimeEntry> logs)
        {
            var settings = new JiraRestClientSettings();

            var logger = _loggingFactory.CreateLogger<Uploader>();

            logger.LogInformation($"Start to upload data to the {_config.BaseApiUrl}");

            var jira = Atlassian.Jira.Jira.CreateRestClient(
                _config.BaseApiUrl,
                _config.UserName,
                pwd,
                settings);

            try
            {
                var result = UploadCore(issues, logs, jira).ConfigureAwait(false).GetAwaiter().GetResult();

                if (result == null)
                {
                    logger.LogWarning("No issues processed.");
                    return;
                }

                logger.LogInformation($"Issues updated: {result.Item1}");
                logger.LogInformation($"Time reported to Jira: {result.Item2}");
                logger.LogInformation($"Time removed from Jira: {result.Item3}");
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
            }
        }

        public async Task UploadAsync(string pwd, IEnumerable<string> issues, IEnumerable<AggregatedTimeEntry> logs, CancellationToken token)
        {
            var settings = new JiraRestClientSettings();

            var logger = _loggingFactory.CreateLogger<Uploader>();

            logger.LogInformation($"Start to upload data to the {_config.BaseApiUrl}");

            var jira = Atlassian.Jira.Jira.CreateRestClient(
                _config.BaseApiUrl,
                _config.UserName,
                pwd,
                settings);

            try
            {
                var result = await UploadCore(issues, logs, jira).ConfigureAwait(false);

                if (result == null)
                {
                    logger.LogWarning("No issues processed.");
                    return;
                }

                logger.LogInformation($"Issues updated: {result.Item1}");
                logger.LogInformation($"Time reported to Jira: {result.Item2}");
                logger.LogInformation($"Time removed from Jira: {result.Item3}");
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
            }
        }

        private async Task<Tuple<int, TimeSpan, TimeSpan>> UploadCore(IEnumerable<string> issues, IEnumerable<AggregatedTimeEntry> logs, Atlassian.Jira.Jira jira)
        {
            var keys = issues as IList<string> ?? issues.ToList();

            var issueCount = 0;
            var timeAddedCount = new TimeSpan();
            long timeDeletedCount = 0;

            foreach (var log in logs)
            {
                if (log.TimeLog.TotalHours > 20)
                {
                    throw new InvalidOperationException("Log could not be more 20 hours per day.");
                }

                var issueKey = keys.FirstOrDefault(k => k.Equals(log.IssueKey));

                if (issueKey == null)
                    continue;

                var worklogs = await jira.Issues.GetWorklogsAsync(issueKey).ConfigureAwait(false);

                var neededLogs = worklogs.Where(wl =>
                    wl.StartDate.HasValue
                    && wl.Author.Equals(_config.UserName)
                    && wl.StartDate.Value.Date.Equals(log.StartDate.Date)).ToList();

                if (neededLogs.Count > 1)
                    throw new InvalidOperationException("There should be the only one log per day.");

                var ewl = neededLogs.FirstOrDefault();

                var logString = new StringBuilder(log.TimeLog.ToString(@"h'h'"));

                if (log.TimeLog.Minutes > 0)
                    logString.Append($" {log.TimeLog.Minutes}m");

                var newWorklog = new Worklog(logString.ToString(), log.StartDate.ToLocalTime(), log.LogComments);

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

            return new Tuple<int, TimeSpan, TimeSpan>(issueCount, timeAddedCount, TimeSpan.FromSeconds(timeDeletedCount));
        }
    }
}