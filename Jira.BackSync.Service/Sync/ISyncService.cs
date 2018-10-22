using System.Threading.Tasks;

namespace Jira.BackSync.Service.Sync
{
    internal interface ISyncService
    {
        void Run();
        Task RunAsync();
    }
}