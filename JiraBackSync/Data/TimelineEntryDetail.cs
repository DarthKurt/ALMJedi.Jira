using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace JiraBackSync.Data
{
    /// <summary>Stores the information about the application in which the user was working during the specified timeline entry.</summary>
    [GeneratedCode("NJsonSchema", "9.4.8.0")]
    public class TimelineEntryDetail : INotifyPropertyChanged
    {
        private int? _activitySeconds;
        private TimelineProcess _timelineProcess;
        private TimelineWindow _timelineWindow;

        /// <summary>Gets or sets the application's activity time in seconds.
        /// Usually, this indicates that a particular window was active.</summary>
        [JsonProperty("activitySeconds", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? ActivitySeconds
        {
            get => _activitySeconds;
            set
            {
                if (_activitySeconds != value)
                {
                    _activitySeconds = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>Gets or sets the process that was active.</summary>
        [JsonProperty("timelineProcess", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public TimelineProcess TimelineProcess
        {
            get => _timelineProcess;
            set
            {
                if (_timelineProcess != value)
                {
                    _timelineProcess = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>Gets or sets the foreground window.</summary>
        [JsonProperty("timelineWindow", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public TimelineWindow TimelineWindow
        {
            get => _timelineWindow;
            set
            {
                if (_timelineWindow != value)
                {
                    _timelineWindow = value;
                    RaisePropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static TimelineEntryDetail FromJson(string data)
        {
            return JsonConvert.DeserializeObject<TimelineEntryDetail>(data);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}