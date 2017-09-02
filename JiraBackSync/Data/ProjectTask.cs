using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace JiraBackSync.Data
{
    [GeneratedCode("NJsonSchema", "9.4.8.0")]
    public class ProjectTask : INotifyPropertyChanged
    {
        private UserProfile _assignee;
        private int? _assigneeId;
        private double? _budgetSize;
        private int? _creatorId;
        private string _description;
        private string _externalIssueId;
        private bool? _showIssueId;
        private int? _integrationId;
        private string _integrationUrl;
        private string _relativeIssueUrl;
        private int? _projectId;
        private int? _projectTaskId;
        private bool? _isCompleted;
        private ObservableCollection<int> _tagsIdentifiers;

        [JsonProperty("assignee", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public UserProfile Assignee
        {
            get => _assignee;
            set
            {
                if (_assignee == value) return;
                _assignee = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("assigneeId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? AssigneeId
        {
            get => _assigneeId;
            set
            {
                if (_assigneeId == value) return;
                _assigneeId = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>Gets or sets budget size.
        /// Can be a money or hours.</summary>
        [JsonProperty("budgetSize", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public double? BudgetSize
        {
            get => _budgetSize;
            set
            {
                if (_budgetSize == value) return;
                _budgetSize = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("creatorId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? CreatorId
        {
            get => _creatorId;
            set
            {
                if (_creatorId != value)
                {
                    _creatorId = value;
                    RaisePropertyChanged();
                }
            }
        }

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

        [JsonProperty("externalIssueId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ExternalIssueId
        {
            get => _externalIssueId;
            set
            {
                if (_externalIssueId != value)
                {
                    _externalIssueId = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("showIssueId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowIssueId
        {
            get => _showIssueId;
            set
            {
                if (_showIssueId != value)
                {
                    _showIssueId = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("integrationId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? IntegrationId
        {
            get => _integrationId;
            set
            {
                if (_integrationId != value)
                {
                    _integrationId = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("integrationUrl", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string IntegrationUrl
        {
            get => _integrationUrl;
            set
            {
                if (_integrationUrl != value)
                {
                    _integrationUrl = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("relativeIssueUrl", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string RelativeIssueUrl
        {
            get => _relativeIssueUrl;
            set
            {
                if (_relativeIssueUrl != value)
                {
                    _relativeIssueUrl = value;
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

        [JsonProperty("projectTaskId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? ProjectTaskId
        {
            get => _projectTaskId;
            set
            {
                if (_projectTaskId != value)
                {
                    _projectTaskId = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty("isCompleted", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsCompleted
        {
            get => _isCompleted;
            set
            {
                if (_isCompleted != value)
                {
                    _isCompleted = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>Gets or sets the tags identifiers.</summary>
        [JsonProperty("tagsIdentifiers", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ObservableCollection<int> TagsIdentifiers
        {
            get => _tagsIdentifiers;
            set
            {
                if (_tagsIdentifiers != value)
                {
                    _tagsIdentifiers = value;
                    RaisePropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static ProjectTask FromJson(string data)
        {
            return JsonConvert.DeserializeObject<ProjectTask>(data);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}