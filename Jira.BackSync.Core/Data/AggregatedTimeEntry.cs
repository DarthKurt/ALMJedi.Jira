using System;

namespace Jira.BackSync.Core.Data
{
    public class AggregatedTimeEntry
    {
        public string IssueKey { get; set; }
        public string LogComments { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public TimeSpan TimeLog { get; set; }
    }
}