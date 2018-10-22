namespace JiraBackSync.Core
{
    public static class SharedConfiguration
    {
        // Hardcoded filename, because all other configuration located in this file.
        // There is no difference in hardcode 'app.config file, any *.ini file, or this common storage.'
        public const string DbName = "store";
        public const string ConfigurationCollectionName = "Configuration";
        public const string XmlKeysFolderPath = "$/SecureKeys/";
        public const string PasswordStorage = "PasswordStorage";
    }
}