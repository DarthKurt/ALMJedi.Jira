using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace JiraBackSync.Data
{
    [GeneratedCode("NJsonSchema", "9.4.8.0")]
    public class SummaryProjectReportRow : INotifyPropertyChanged
    {
        private string _project;
        private int? _projectId;
        private string _client;
        private int? _clientId;
        private ObservableCollection<Money> _costs;
        private double? _duration;
        private double? _billableDuration;
        private ObservableCollection<Money> _billableAmount;

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

        [JsonProperty("costs", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ObservableCollection<Money> Costs
        {
            get => _costs;
            set
            {
                if (_costs != value)
                {
                    _costs = value;
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

        public static SummaryProjectReportRow FromJson(string data)
        {
            return JsonConvert.DeserializeObject<SummaryProjectReportRow>(data);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}