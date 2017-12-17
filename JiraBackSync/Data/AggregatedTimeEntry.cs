using System;
using Atlassian.Jira;

namespace JiraBackSync.Data
{
    internal class AggregatedTimeEntry
    {
        public ComparableString IssueKey { get; set; }
        public ComparableString LogComments { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public TimeSpan TimeLog { get; set; }
    }
}