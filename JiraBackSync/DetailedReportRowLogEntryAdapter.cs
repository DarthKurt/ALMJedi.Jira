using System;
using System.Collections.Generic;
using System.Linq;
using JiraBackSync.Data;

namespace JiraBackSync
{
    internal class DetailedReportRowAggregatedTimeEntryAdapter
    {
        private const int MillisecondsInDay = 86400000;

        public static AggregatedTimeEntry CreateLogEntry(IEnumerable<DetailedReportRow> rows)
        {
            var detailedReportRows = rows as IList<DetailedReportRow>
                ?? rows.OrderBy(r => r.StartTime).ToList();

            var res = new AggregatedTimeEntry();

            if (!CheckEntryKey(detailedReportRows))
                return res;

            if (!CheckEntryDate(detailedReportRows))
                throw new ArgumentException("Invalid row set. There are entries from different days.");

            res.StartDate = FindStartDateTime(detailedReportRows);
            res.TimeLog = CalculateTime(detailedReportRows);
            res.IssueKey = detailedReportRows.FirstOrDefault()?.IssueId;

            return res;
        }

        private static DateTime FindStartDateTime(IEnumerable<DetailedReportRow> rows)
        {
            var dt = rows.FirstOrDefault()?.StartTime;// assume the list is sorted before

            if (!dt.HasValue)
                throw new ArgumentException("Not all rows contain Start Time.");

            return dt.Value;
        }

        private static TimeSpan CalculateTime(IEnumerable<DetailedReportRow> rows)
        {
            var dt = rows.Sum(r => r.Duration);

            if (!dt.HasValue || dt.Value > MillisecondsInDay)
                throw new ArgumentException("Invalid dudarion for 1 Day");

            return TimeSpan.FromMilliseconds(dt.Value);
        }

        private static bool CheckEntryDate(IList<DetailedReportRow> rows)
        {
            var dt = rows.FirstOrDefault()?.Day;

            if (!dt.HasValue)
                throw new ArgumentException("Not all rows contain Day.");

            return rows.All(e => e.Day == dt);
        }

        private static bool CheckEntryKey(IList<DetailedReportRow> rows)
        {
            var entryKey = rows.FirstOrDefault()?.TimeEntry;
            var issueKey = rows.FirstOrDefault()?.IssueId;

            if (string.IsNullOrWhiteSpace(entryKey) || string.IsNullOrWhiteSpace(issueKey))
                return false;

            if(!rows.All(e => string.Equals(e.TimeEntry, entryKey) && string.Equals(e.IssueId, issueKey)))
                throw new ArgumentException("Invalid row set. There are entries with different names.");

            return true;
        }
    }
}