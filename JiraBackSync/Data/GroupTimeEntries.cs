using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace JiraBackSync.Data
{
    [GeneratedCode("NJsonSchema", "9.4.8.0")]
    public class GroupTimeEntries : INotifyPropertyChanged
    {
        private int? _userProfileId;
        private string _userName;
        private ObservableCollection<TimeEntry> _entries;

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

        [JsonProperty("userName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string UserName
        {
            get => _userName;
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("entries", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ObservableCollection<TimeEntry> Entries
        {
            get => _entries;
            set
            {
                if (_entries != value)
                {
                    _entries = value;
                    RaisePropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static GroupTimeEntries FromJson(string data)
        {
            return JsonConvert.DeserializeObject<GroupTimeEntries>(data);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}