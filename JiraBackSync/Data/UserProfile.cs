using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace JiraBackSync.Data
{
    [GeneratedCode("NJsonSchema", "9.4.8.0")]
    public class UserProfile : INotifyPropertyChanged
    {
        private int? _userProfileId;
        private int? _activeAccountId;
        private string _userName;
        private string _dateFormat;
        private string _timeFormat;
        private bool? _showBreaks;
        private TimeZoneInfoLite _timeZoneInfo;
        private bool? _isRegistered;
        private string _email;
        private ObservableCollection<object> _accountMembership;
        private bool? _isAuthenticatedExternally;

        [JsonProperty("userProfileId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? UserProfileId
        {
            get => _userProfileId;
            set
            {
                if (_userProfileId != value)
                {
                    _userProfileId = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("activeAccountId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? ActiveAccountId
        {
            get => _activeAccountId;
            set
            {
                if (_activeAccountId != value)
                {
                    _activeAccountId = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>Gets or sets end-User's full name in displayable form including all name parts,
        /// possibly including titles and suffixes, ordered according to the End-User's locale and preferences.</summary>
        [JsonProperty("userName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string UserName
        {
            get => _userName;
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("dateFormat", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DateFormat
        {
            get => _dateFormat;
            set
            {
                if (_dateFormat != value)
                {
                    _dateFormat = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>Gets or sets the time format.</summary>
        [JsonProperty("timeFormat", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TimeFormat
        {
            get => _timeFormat;
            set
            {
                if (_timeFormat != value)
                {
                    _timeFormat = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("showBreaks", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowBreaks
        {
            get => _showBreaks;
            set
            {
                if (_showBreaks != value)
                {
                    _showBreaks = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>Gets or sets the time zone information.</summary>
        [JsonProperty("timeZoneInfo", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public TimeZoneInfoLite TimeZoneInfo
        {
            get => _timeZoneInfo;
            set
            {
                if (_timeZoneInfo != value)
                {
                    _timeZoneInfo = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("isRegistered", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsRegistered
        {
            get => _isRegistered;
            set
            {
                if (_isRegistered != value)
                {
                    _isRegistered = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("email", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>Gets or sets the collection of objects the define the user's membership in service accounts.
        /// This collection defines which service accounts the user can access.
        /// Accounts where user is locked are not included in the list.</summary>
        [JsonProperty("accountMembership", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ObservableCollection<object> AccountMembership
        {
            get => _accountMembership;
            set
            {
                if (_accountMembership != value)
                {
                    _accountMembership = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether user is authenticated externally (e.g. via Google).</summary>
        [JsonProperty("isAuthenticatedExternally", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsAuthenticatedExternally
        {
            get => _isAuthenticatedExternally;
            set
            {
                if (_isAuthenticatedExternally != value)
                {
                    _isAuthenticatedExternally = value;
                    RaisePropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static UserProfile FromJson(string data)
        {
            return JsonConvert.DeserializeObject<UserProfile>(data);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}