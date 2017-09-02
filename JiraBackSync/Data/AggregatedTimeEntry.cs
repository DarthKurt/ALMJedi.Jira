using System;
using Atlassian.Jira;

namespace JiraBackSync.Data
{
    internal class AggregatedTimeEntry
    {
        public ComparableString IssueKey { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan TimeLog { get; set; }
    }
}