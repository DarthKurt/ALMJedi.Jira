using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace JiraBackSync.Data
{
    [GeneratedCode("NJsonSchema", "9.4.8.0")]
    public class TimeEntry : INotifyPropertyChanged
    {
        private DateTime? _endTime;
        private DateTime? _startTime;
        private bool? _isBillable;
        private bool? _isInvoiced;
        private long? _timeEntryId;
        private TimeEntryDetail _details;
        private string _projectName;
        private ObservableCollection<int> _tagsIdentifiers;

        /// <summary>Gets or sets the end time value for a external data contract. If EndTime == null this means that the time entry is active.</summary>
        [JsonProperty("endTime", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? EndTime
        {
            get => _endTime;
            set
            {
                if (_endTime != value)
                {
                    _endTime = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("startTime", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? StartTime
        {
            get => _startTime;
            set
            {
                if (_startTime != value)
                {
                    _startTime = value;
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

        [JsonProperty("isInvoiced", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsInvoiced
        {
            get => _isInvoiced;
            set
            {
                if (_isInvoiced != value)
                {
                    _isInvoiced = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("timeEntryId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public long? TimeEntryId
        {
            get => _timeEntryId;
            set
            {
                if (_timeEntryId != value)
                {
                    _timeEntryId = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("details", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public TimeEntryDetail Details
        {
            get => _details;
            set
            {
                if (_details != value)
                {
                    _details = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>Fill it on our own if needed.</summary>
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

        /// <summary>Gets or sets the tags identifiers.</summary>
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

        public event PropertyChangedEventHandler PropertyChanged;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static TimeEntry FromJson(string data)
        {
            return JsonConvert.DeserializeObject<TimeEntry>(data);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}