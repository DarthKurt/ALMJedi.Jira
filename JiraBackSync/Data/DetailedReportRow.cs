using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace JiraBackSync.Data
{
    [GeneratedCode("NJsonSchema", "9.10.14.0")]
    public class DetailedReportRow : INotifyPropertyChanged
    {
        private DateTime? _day;
        private DateTime? _startTime;
        private DateTime? _endTime;
        private string _user;
        private int? _userProfileId;
        private string _project;
        private int? _projectId;
        private string _projectCode;
        private string _client;
        private int? _clientId;
        private int? _projectTaskId;
        private string _description;
        private string _issueUrl;
        private string _issueId;
        private ObservableCollection<string> _tags;
        private double? _duration;
        private double? _billableDuration;
        private ObservableCollection<Money> _billableAmount;

        /// <summary>The noon timestamp of reported day (#65331)</summary>
        [JsonProperty("day", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? Day
        {
            get => _day;
            set
            {
                if (_day == value)
                    return;
                _day = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("startTime", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? StartTime
        {
            get => _startTime;
            set
            {
                if (_startTime == value)
                    return;
                _startTime = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("endTime", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? EndTime
        {
            get => _endTime;
            set
            {
                if (_endTime == value)
                    return;
                _endTime = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("user", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string User
        {
            get => _user;
            set
            {
                if (_user == value)
                    return;
                _user = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("userProfileId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? UserProfileId
        {
            get => _userProfileId;
            set
            {
                if (_userProfileId == value)
                    return;
                _userProfileId = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("project", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Project
        {
            get => _project;
            set
            {
                if (_project == value)
                    return;
                _project = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("projectId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? ProjectId
        {
            get => _projectId;
            set
            {
                if (_projectId == value)
                    return;
                _projectId = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("projectCode", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ProjectCode
        {
            get => _projectCode;
            set
            {
                if (_projectCode == value)
                    return;
                _projectCode = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("client", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Client
        {
            get => _client;
            set
            {
                if (_client == value)
                    return;
                _client = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("clientId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? ClientId
        {
            get => _clientId;
            set
            {
                if (_clientId == value)
                    return;
                _clientId = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("projectTaskId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? ProjectTaskId
        {
            get => _projectTaskId;
            set
            {
                if (_projectTaskId == value)
                    return;
                _projectTaskId = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Description
        {
            get => _description;
            set
            {
                if (_description == value)
                    return;
                _description = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("issueUrl", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string IssueUrl
        {
            get => _issueUrl;
            set
            {
                if (_issueUrl == value)
                    return;
                _issueUrl = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("issueId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string IssueId
        {
            get => _issueId;
            set
            {
                if (_issueId == value)
                    return;
                _issueId = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("tags", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ObservableCollection<string> Tags
        {
            get => _tags;
            set
            {
                if (_tags == value)
                    return;
                _tags = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("duration", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? Duration
        {
            get => _duration;
            set
            {
                if (_duration != null && _duration == value)
                    return;
                _duration = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("billableDuration", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? BillableDuration
        {
            get => _billableDuration;
            set
            {
                if (_billableDuration != null && _billableDuration == value)
                    return;
                _billableDuration = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("billableAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ObservableCollection<Money> BillableAmount
        {
            get => _billableAmount;
            set
            {
                if (_billableAmount == value)
                    return;
                _billableAmount = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static DetailedReportRow FromJson(string data)
        {
            return JsonConvert.DeserializeObject<DetailedReportRow>(data);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}