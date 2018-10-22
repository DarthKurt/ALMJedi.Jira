using System.Threading.Tasks;

namespace JiraBackSync.Service.Sync
{
    internal interface ISyncService
    {
        void Run();
        Task RunAsync();
    }
}