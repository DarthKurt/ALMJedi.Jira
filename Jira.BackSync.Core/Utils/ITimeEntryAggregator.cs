using System.Collections.Generic;
using System.Threading.Tasks;
using Jira.BackSync.Core.Data;

namespace Jira.BackSync.Core.Utils
{
    public interface ITimeEntryAggregator
    {
        Task<IEnumerable<AggregatedTimeEntry>> GetReportAsync();
    }
}