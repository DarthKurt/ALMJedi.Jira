using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jira.BackSync.Core.Utils;
using Jira.BackSync.Service.Load;
using Microsoft.Extensions.Logging;

namespace Jira.BackSync.Service.Sync
{
    internal class SyncService: ISyncService
    {
        private readonly ILoadService _loadService;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ISecurityService _security;
        private readonly IUploader _uploader;

        public SyncService(ILoadService loadService, ILoggerFactory loggerFactory, ISecurityService security, IUploader uploader)
        {
            _loadService = loadService;
            _loggerFactory = loggerFactory;
            _security = security;
            _uploader = uploader;
        }

        public void Run()
        {
            var logger = _loggerFactory.CreateLogger<TmetricLoadService>();

            var logs = _loadService.Load();
            var aggregatedTimeEntries = logs.ToList();

            logger.LogInformation($"Aggregated entries found: {aggregatedTimeEntries.Count}");

            var issueKeys = aggregatedTimeEntries.Select(e => e.IssueKey).Distinct();
            var pwd = _security.Decrypt("JiraPassword");

            _uploader.Upload(pwd, issueKeys, aggregatedTimeEntries);
        }

        public async Task RunAsync()
        {
            var logger = _loggerFactory.CreateLogger<TmetricLoadService>();

            var logs = await _loadService.LoadAsync().ConfigureAwait(false);
            var aggregatedTimeEntries = logs.ToList();

            logger.LogInformation($"Aggregated entries found: {aggregatedTimeEntries.Count}");

            var issueKeys = aggregatedTimeEntries.Select(e => e.IssueKey).Distinct();
            var pwd = _security.Decrypt("JiraPassword");

            await _uploader.UploadAsync(pwd, issueKeys, aggregatedTimeEntries, CancellationToken.None).ConfigureAwait(false);
        }
    }
}