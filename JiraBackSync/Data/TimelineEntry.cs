using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace JiraBackSync.Data
{
    /// <summary>Represents a time entry of aggregated user's activity. The entrys are aligned to clock.
    /// The first time line in a day starts at 00:00. Entry duration is 15 minutes.</summary>
    [GeneratedCode("NJsonSchema", "9.4.8.0")]
    public class TimelineEntry : INotifyPropertyChanged
    {
        private ObservableCollection<TimelineEntryDetail> _details;
        private DateTime _startTime;

        /// <summary>Gets or sets the timeline entry details.</summary>
        [JsonProperty("details", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ObservableCollection<TimelineEntryDetail> Details
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

        /// <summary>Gets or sets the start time (UTC) of the timeline entry.</summary>
        [JsonProperty("startTime", Required = Required.Always)]
        [Required]
        public DateTime StartTime
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

        public event PropertyChangedEventHandler PropertyChanged;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static TimelineEntry FromJson(string data)
        {
            return JsonConvert.DeserializeObject<TimelineEntry>(data);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}