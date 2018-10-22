using System.Collections.Generic;
using System.Threading.Tasks;
using Jira.BackSync.Core.Data;

namespace Jira.BackSync.Service.Load
{
    internal interface ILoadService
    {
        IEnumerable<AggregatedTimeEntry> Load();
        Task<IEnumerable<AggregatedTimeEntry>> LoadAsync();
    }
}