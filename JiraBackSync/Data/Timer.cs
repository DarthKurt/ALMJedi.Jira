using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace JiraBackSync.Data
{
    /// <summary>Represents the timer abstraction.</summary>
    [GeneratedCode("NJsonSchema", "9.4.8.0")]
    public class Timer : INotifyPropertyChanged
    {
        private bool? _isStarted;
        private TimeEntryDetail _details;
        private DateTime? _startTime;
        private ObservableCollection<int> _tagsIdentifiers;
        private bool? _isBillable;

        /// <summary>Gets or sets a value indicating whether the timer is started.</summary>
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

        /// <summary>Gets or sets the current task description.</summary>
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

        /// <summary>Gets or sets the timer's start time.</summary>
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

        /// <summary>Gets or sets the billable status.</summary>
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

        public event PropertyChangedEventHandler PropertyChanged;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Timer FromJson(string data)
        {
            return JsonConvert.DeserializeObject<Timer>(data);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}