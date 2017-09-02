using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace JiraBackSync.Data
{
    [GeneratedCode("NJsonSchema", "9.4.8.0")]
    public class TaskReportRow : INotifyPropertyChanged
    {
        private string _user;
        private int? _userProfileId;
        private string _project;
        private int? _projectId;
        private string _client;
        private int? _clientId;
        private int? _projectTaskId;
        private string _timeEntry;
        private string _issueUrl;
        private string _issueId;
        private ObservableCollection<string> _tags;
        private double? _duration;
        private double? _billableDuration;
        private ObservableCollection<Money> _billableAmount;

        [JsonProperty("user", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string User
        {
            get => _user;
            set
            {
                if (_user != value)
                {
                    _user = value;
                    RaisePropertyChanged();
                }
            }
        }

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

        [JsonProperty("project", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Project
        {
            get => _project;
            set
            {
                if (_project != value)
                {
                    _project = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("projectId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? ProjectId
        {
            get => _projectId;
            set
            {
                if (_projectId != value)
                {
                    _projectId = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("client", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Client
        {
            get => _client;
            set
            {
                if (_client != value)
                {
                    _client = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("clientId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? ClientId
        {
            get => _clientId;
            set
            {
                if (_clientId != value)
                {
                    _clientId = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("projectTaskId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? ProjectTaskId
        {
            get => _projectTaskId;
            set
            {
                if (_projectTaskId != value)
                {
                    _projectTaskId = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("timeEntry", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TimeEntry
        {
            get => _timeEntry;
            set
            {
                if (_timeEntry != value)
                {
                    _timeEntry = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("issueUrl", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string IssueUrl
        {
            get => _issueUrl;
            set
            {
                if (_issueUrl != value)
                {
                    _issueUrl = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("issueId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string IssueId
        {
            get => _issueId;
            set
            {
                if (_issueId != value)
                {
                    _issueId = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("tags", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ObservableCollection<string> Tags
        {
            get => _tags;
            set
            {
                if (_tags != value)
                {
                    _tags = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("duration", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? Duration
        {
            get => _duration;
            set
            {
                if (_duration != value)
                {
                    _duration = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("billableDuration", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? BillableDuration
        {
            get => _billableDuration;
            set
            {
                if (_billableDuration != value)
                {
                    _billableDuration = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("billableAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ObservableCollection<Money> BillableAmount
        {
            get => _billableAmount;
            set
            {
                if (_billableAmount != value)
                {
                    _billableAmount = value;
                    RaisePropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static TaskReportRow FromJson(string data)
        {
            return JsonConvert.DeserializeObject<TaskReportRow>(data);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}