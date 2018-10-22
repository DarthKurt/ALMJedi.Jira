namespace JiraBackSync.Storage.Data
{
    internal class PasswordEntry
    {
        public PasswordEntry()
        {}

        public PasswordEntry(byte[] data, string key)
        {
            Data = data;
            Key = key;
        }

        public string Key { get; set; }
        public byte[] Data { get; set; }
    }
}