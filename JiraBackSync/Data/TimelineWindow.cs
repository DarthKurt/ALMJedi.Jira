using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace JiraBackSync.Data
{
    /// <summary>Stores the information about the foreground window that was active during a timeline entry.</summary>
    [GeneratedCode("NJsonSchema", "9.4.8.0")]
    public class TimelineWindow : INotifyPropertyChanged
    {
        private string _windowText;

        /// <summary>Gets or sets the name of the foreground window that used worked in.</summary>
        [JsonProperty("windowText", Required = Required.Always)]
        [Required]
        public string WindowText
        {
            get => _windowText;
            set
            {
                if (_windowText != value)
                {
                    _windowText = value;
                    RaisePropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static TimelineWindow FromJson(string data)
        {
            return JsonConvert.DeserializeObject<TimelineWindow>(data);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}