namespace JiraBackSync.Core.Utils
{
    public interface IPasswordStorage
    {
        void Save(string key, byte[] toSave);
        byte[] Load(string key);
    }
}