using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Jira.BackSync.Core.Data;

namespace Jira.BackSync.Core.Utils
{
    public interface IUploader
    {
        void Upload(string pwd, IEnumerable<string> issues, IEnumerable<AggregatedTimeEntry> logs);

        Task UploadAsync(string pwd, IEnumerable<string> issues, IEnumerable<AggregatedTimeEntry> logs, CancellationToken token);
    }
}