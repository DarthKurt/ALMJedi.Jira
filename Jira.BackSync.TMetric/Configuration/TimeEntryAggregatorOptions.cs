namespace Jira.BackSync.TMetric.Configuration
{
    public sealed class TimeEntryAggregatorOptions
    {
        public int AccountId { get; set; }
        public int[] ProjectIds { get; set; }
        public string BaseApiUrl { get; set; }
        public string ApiKey { get; set; }
    }
}