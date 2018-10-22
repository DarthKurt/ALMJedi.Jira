using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JiraBackSync.Core.Data;
using JiraBackSync.Core.Utils;
using Microsoft.Extensions.Logging;

namespace JiraBackSync.Service.Load
{
    internal class TmetricLoadService : ILoadService
    {
        private readonly ITimeEntryAggregator _timeEntryAggregator;
        private readonly ILoggerFactory _loggerFactory;

        public TmetricLoadService(ITimeEntryAggregator timeEntryAggregator, ILoggerFactory loggerFactory)
        {
            _timeEntryAggregator = timeEntryAggregator;
            _loggerFactory = loggerFactory;
        }

        public IEnumerable<AggregatedTimeEntry> Load()
        {
            var logger = _loggerFactory.CreateLogger<TmetricLoadService>();
            try
            {
                return _timeEntryAggregator.GetReportAsync().GetAwaiter().GetResult();
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
                return new AggregatedTimeEntry[]{};
            }
        }

        public Task<IEnumerable<AggregatedTimeEntry>> LoadAsync()
        {
            var logger = _loggerFactory.CreateLogger<TmetricLoadService>();
            try
            {
                return _timeEntryAggregator.GetReportAsync();
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
                return Task.FromResult(new AggregatedTimeEntry[]{}.AsEnumerable());
            }
        }
    }
}