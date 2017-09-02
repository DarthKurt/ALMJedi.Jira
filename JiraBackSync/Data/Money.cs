using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace JiraBackSync.Data
{
    /// <summary>Represents an abstraction for manipulating money amounts in different currencies.</summary>
    [GeneratedCode("NJsonSchema", "9.4.8.0")]
    public class Money : INotifyPropertyChanged
    {
        private double? _amount;
        private string _currency;

        /// <summary>Gets or sets the money amount.</summary>
        [JsonProperty("amount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? Amount
        {
            get => _amount;
            set
            {
                if (_amount == value) return;
                _amount = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>Gets or sets the currency.</summary>
        [JsonProperty("currency", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Currency
        {
            get => _currency;
            set
            {
                if (_currency == value) return;
                _currency = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Money FromJson(string data)
        {
            return JsonConvert.DeserializeObject<Money>(data);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}