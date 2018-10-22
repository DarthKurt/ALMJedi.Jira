namespace Jira.BackSync.Core.Utils
{
    public interface ISecurityService
    {
        void PersistPassword(string key, string toEncrypt);

        string Decrypt(string key);
    }
}