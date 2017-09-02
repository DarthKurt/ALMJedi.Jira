using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace JiraBackSync.Data
{
    [GeneratedCode("NJsonSchema", "9.4.8.0")]
    public class TimeEntryDetail : INotifyPropertyChanged
    {
        private string _description;
        private int? _projectId;
        private ProjectTask _projectTask;

        [JsonProperty("description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
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

        [JsonProperty("projectTask", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ProjectTask ProjectTask
        {
            get => _projectTask;
            set
            {
                if (_projectTask != value)
                {
                    _projectTask = value;
                    RaisePropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static TimeEntryDetail FromJson(string data)
        {
            return JsonConvert.DeserializeObject<TimeEntryDetail>(data);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}