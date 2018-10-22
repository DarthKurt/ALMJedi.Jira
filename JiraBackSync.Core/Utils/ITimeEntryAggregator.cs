using System.Collections.Generic;
using System.Threading.Tasks;
using JiraBackSync.Core.Data;

namespace JiraBackSync.Core.Utils
{
    public interface ITimeEntryAggregator
    {
        Task<IEnumerable<AggregatedTimeEntry>> GetReportAsync();
    }
}