using System;
using System.Linq;
using System.Text;
using Jira.BackSync.Core.Utils;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace Jira.BackSync.Security
{
    public class SecurityService: ISecurityService
    {
        private readonly IKeyManager _keyManager;
        private readonly IPasswordStorage _passwordStorage;

        public SecurityService(IKeyManager keyManager, IPasswordStorage passwordStorage)
        {
            _keyManager = keyManager;
            _passwordStorage = passwordStorage;
        }

        public void PersistPassword(string key, string toEncrypt)
        {
            var securityKey = _keyManager.GetAllKeys().FirstOrDefault()
                              ?? _keyManager.CreateNewKey(DateTimeOffset.UtcNow, DateTimeOffset.MaxValue);

            var bytes = Encoding.UTF8.GetBytes(toEncrypt);

            var result = securityKey.CreateEncryptor().Encrypt(new ArraySegment<byte>(bytes), new ArraySegment<byte>(new byte[]{}));
            _passwordStorage.Save(key, result);
        }

        public string Decrypt(string key)
        {
            var securityKey = _keyManager.GetAllKeys().FirstOrDefault();
            if (securityKey == null)
                return string.Empty;

            var bytes = _passwordStorage.Load(key);

            var result = securityKey.CreateEncryptor().Decrypt(new ArraySegment<byte>(bytes), new ArraySegment<byte>(new byte[] { }));
            return Encoding.UTF8.GetString(result);
        }
    }
}