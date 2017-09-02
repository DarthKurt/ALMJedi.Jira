﻿using System.CodeDom.Compiler;







{
    [GeneratedCode("NJsonSchema", "9.4.8.0")]

    {
        private int? _userGroupId;
        private int? _accountId;
        private string _name;
        private ObservableCollection<UserGroupMember> _members;
        private ObservableCollection<UserGroupSupervisor> _supervisors;

        [JsonProperty("userGroupId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]


            get => _userGroupId;

            {




        }

        [JsonProperty("accountId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]


            get => _accountId;

            {




        }

        [JsonProperty("name", Required = Required.Always)]



            get => _name;

            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("members", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]


            get => _members;

            {
                if (_members != value)
                {
                    _members = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("supervisors", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]


            get => _supervisors;

            {
                if (_supervisors != value)
                {
                    _supervisors = value;
                    RaisePropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static UserGroup FromJson(string data)
        {
            return JsonConvert.DeserializeObject<UserGroup>(data);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}