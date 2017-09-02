using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace JiraBackSync.Data
{
    [GeneratedCode("NJsonSchema", "9.4.8.0")]
    public class UserGroup : INotifyPropertyChanged
    {
        private int? _userGroupId;
        private int? _accountId;
        private string _name;
        private ObservableCollection<UserGroupMember> _members;
        private ObservableCollection<UserGroupSupervisor> _supervisors;

        [JsonProperty("userGroupId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? UserGroupId
        {
            get => _userGroupId;
            set
            {
                if (_userGroupId == value) return;
                _userGroupId = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("accountId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? AccountId
        {
            get => _accountId;
            set
            {
                if (_accountId == value) return;
                _accountId = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("name", Required = Required.Always)]
        [Required]
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("members", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ObservableCollection<UserGroupMember> Members
        {
            get => _members;
            set
            {
                if (_members != value)
                {
                    _members = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("supervisors", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ObservableCollection<UserGroupSupervisor> Supervisors
        {
            get => _supervisors;
            set
            {
                if (_supervisors != value)
                {
                    _supervisors = value;
                    RaisePropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static UserGroup FromJson(string data)
        {
            return JsonConvert.DeserializeObject<UserGroup>(data);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}