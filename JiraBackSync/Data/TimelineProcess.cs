using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace JiraBackSync.Data
{
    /// <summary>Stores the information about the process that was active during a timeline entry.</summary>
    [GeneratedCode("NJsonSchema", "9.4.8.0")]
    public class TimelineProcess : INotifyPropertyChanged
    {
        private string _processName;

        /// <summary>Gets or sets the name of the main process module (.exe file).</summary>
        [JsonProperty("processName", Required = Required.Always)]
        [Required]
        public string ProcessName
        {
            get => _processName;
            set
            {
                if (_processName == value)
                    return;
                _processName = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static TimelineProcess FromJson(string data)
        {
            return JsonConvert.DeserializeObject<TimelineProcess>(data);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}