using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JiraBackSync.Core.Data;
using JiraBackSync.Core.Utils;
using JiraBackSync.TMetric.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace JiraBackSync.TMetric
{
    public class TimeEntryAggregator: ITimeEntryAggregator
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ITimeUtils _timeUtils;
        private readonly TimeEntryAggregatorOptions _config;

        public TimeEntryAggregator(ILoggerFactory loggingFactory, ITimeUtils timeUtils, IOptions<TimeEntryAggregatorOptions> config)
        {
            _loggerFactory = loggingFactory;
            _timeUtils = timeUtils;
            _config = config.Value;
        }

        public async Task<IEnumerable<AggregatedTimeEntry>> GetReportAsync()
        {
            var logger = _loggerFactory.CreateLogger<TimeEntryAggregator>();
            logger.LogInformation("Starting download...");

            var apiClient = new ReportDetailedClient(_config.BaseApiUrl, _config.ApiKey);

            var logs = await apiClient.GetDetailedReportAsync(_config.ProjectIds, null, null, true, true, null, null,
                _config.AccountId, _timeUtils.StartOfWeek, _timeUtils.EndOfWeek).ConfigureAwait(false);

            logger.LogInformation($"Reported entries found: {logs.Count}");

            return logs.GroupBy(r => new { r.Day, r.IssueId })
                .Select(DetailedReportRowAggregatedTimeEntryAdapter.CreateLogEntry)
                .Where(c => c.IssueKey != null);
        }
    }
}