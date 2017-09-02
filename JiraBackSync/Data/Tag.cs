using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace JiraBackSync.Data
{
    [GeneratedCode("NJsonSchema", "9.4.8.0")]
    public class Tag : INotifyPropertyChanged
    {
        private int? _tagId;
        private string _tagName;
        private int? _accountId;
        private Rate _defaultBillableRate;

        [JsonProperty("tagId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? TagId
        {
            get => _tagId;
            set
            {
                if (_tagId == value) return;
                _tagId = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("tagName", Required = Required.Always)]
        [Required]
        public string TagName
        {
            get => _tagName;
            set
            {
                if (_tagName == value) return;
                _tagName = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("accountId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? AccountId
        {
            get => _accountId;
            set
            {
                if (_accountId == value) return;
                _accountId = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("defaultBillableRate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public Rate DefaultBillableRate
        {
            get => _defaultBillableRate;
            set
            {
                if (_defaultBillableRate == value) return;
                _defaultBillableRate = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Tag FromJson(string data)
        {
            return JsonConvert.DeserializeObject<Tag>(data);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}