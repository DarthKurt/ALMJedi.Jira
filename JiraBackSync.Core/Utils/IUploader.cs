using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JiraBackSync.Core.Data;

namespace JiraBackSync.Core.Utils
{
    public interface IUploader
    {
        void Upload(string pwd, IEnumerable<string> issues, IEnumerable<AggregatedTimeEntry> logs);

        Task UploadAsync(string pwd, IEnumerable<string> issues, IEnumerable<AggregatedTimeEntry> logs, CancellationToken token);
    }
}