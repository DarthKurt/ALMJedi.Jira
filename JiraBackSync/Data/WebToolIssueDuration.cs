using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace JiraBackSync.Data
{
    [GeneratedCode("NJsonSchema", "9.4.8.0")]
    public class WebToolIssueDuration : INotifyPropertyChanged
    {
        private long? _duration;
        private string _serviceUrl;
        private string _issueUrl;

        [JsonProperty("duration", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public long? Duration
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

        public static WebToolIssueDuration FromJson(string data)
        {
            return JsonConvert.DeserializeObject<WebToolIssueDuration>(data);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}