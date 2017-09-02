using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace JiraBackSync.Data
{
    [GeneratedCode("NJsonSchema", "9.4.8.0")]
    public class WebToolIssueTimer : INotifyPropertyChanged
    {
        private bool? _isStarted;
        private ObservableCollection<int> _tagsIdentifiers;
        private bool? _isBillable;
        private string _issueId;
        private string _issueName;
        private string _serviceType;
        private string _projectName;
        private bool? _showIssueId;
        private string _serviceUrl;
        private string _issueUrl;

        [JsonProperty("isStarted", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsStarted
        {
            get => _isStarted;
            set
            {
                if (_isStarted != value)
                {
                    _isStarted = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("tagsIdentifiers", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ObservableCollection<int> TagsIdentifiers
        {
            get => _tagsIdentifiers;
            set
            {
                if (_tagsIdentifiers != value)
                {
                    _tagsIdentifiers = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("isBillable", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsBillable
        {
            get => _isBillable;
            set
            {
                if (_isBillable != value)
                {
                    _isBillable = value;
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

        [JsonProperty("issueName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string IssueName
        {
            get => _issueName;
            set
            {
                if (_issueName != value)
                {
                    _issueName = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("serviceType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ServiceType
        {
            get => _serviceType;
            set
            {
                if (_serviceType != value)
                {
                    _serviceType = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("projectName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ProjectName
        {
            get => _projectName;
            set
            {
                if (_projectName != value)
                {
                    _projectName = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("showIssueId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowIssueId
        {
            get => _showIssueId;
            set
            {
                if (_showIssueId != value)
                {
                    _showIssueId = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("serviceUrl", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ServiceUrl
        {
            get => _serviceUrl;
            set
            {
                if (_serviceUrl != value)
                {
                    _serviceUrl = value;
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

        public event PropertyChangedEventHandler PropertyChanged;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static WebToolIssueTimer FromJson(string data)
        {
            return JsonConvert.DeserializeObject<WebToolIssueTimer>(data);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}