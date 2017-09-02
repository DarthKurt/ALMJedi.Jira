using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace JiraBackSync.Data
{
    [GeneratedCode("NJsonSchema", "9.4.8.0")]
    public class WebToolIssueIdentifier : INotifyPropertyChanged
    {
        private string _serviceUrl;
        private string _issueUrl;

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

        public static WebToolIssueIdentifier FromJson(string data)
        {
            return JsonConvert.DeserializeObject<WebToolIssueIdentifier>(data);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}