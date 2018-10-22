using System.Collections.Generic;
using System.Threading.Tasks;
using JiraBackSync.Core.Data;

namespace JiraBackSync.Service.Load
{
    internal interface ILoadService
    {
        IEnumerable<AggregatedTimeEntry> Load();
        Task<IEnumerable<AggregatedTimeEntry>> LoadAsync();
    }
}