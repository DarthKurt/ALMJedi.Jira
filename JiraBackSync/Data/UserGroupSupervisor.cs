using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace JiraBackSync.Data
{
    [GeneratedCode("NJsonSchema", "9.4.8.0")]
    public class UserGroupSupervisor : INotifyPropertyChanged
    {
        private int? _userProfileId;
        private UserProfile _userProfile;
        private int? _userGroupId;
        private int? _accountId;

        [JsonProperty("userProfileId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? UserProfileId
        {
            get => _userProfileId;
            set
            {
                if (_userProfileId != value)
                {
                    _userProfileId = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("userProfile", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public UserProfile UserProfile
        {
            get => _userProfile;
            set
            {
                if (_userProfile != value)
                {
                    _userProfile = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("userGroupId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? UserGroupId
        {
            get => _userGroupId;
            set
            {
                if (_userGroupId != value)
                {
                    _userGroupId = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("accountId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? AccountId
        {
            get => _accountId;
            set
            {
                if (_accountId != value)
                {
                    _accountId = value;
                    RaisePropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static UserGroupSupervisor FromJson(string data)
        {
            return JsonConvert.DeserializeObject<UserGroupSupervisor>(data);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}