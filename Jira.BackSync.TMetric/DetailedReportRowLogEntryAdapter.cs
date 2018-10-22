using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jira.BackSync.Core.Data;
using Jira.BackSync.TMetric.Data;

namespace Jira.BackSync.TMetric
{
    internal static class DetailedReportRowAggregatedTimeEntryAdapter
    {
        private const int MillisecondsInDay = 86400000;

        public static AggregatedTimeEntry CreateLogEntry(this IEnumerable<DetailedReportRow> rows)
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
            res.LogComments = AggregateComments(detailedReportRows);

            return res;
        }

        #region Private


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

        private static string AggregateComments(IEnumerable<DetailedReportRow> rows)
        {
            var detailedReportDecriptions = rows
                .Where(r => !string.IsNullOrWhiteSpace(r?.Description))
                .Select(r => r.Description)
                .Distinct()
                .ToList();
            if (!detailedReportDecriptions.Any())
                return string.Empty;

            if (detailedReportDecriptions.Count.Equals(1))
                return detailedReportDecriptions.First();

            var res = new StringBuilder();

            foreach (var detailedReportDecription in detailedReportDecriptions)
            {
                res.AppendLine($" - {detailedReportDecription}");
            }
            return res.ToString();
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
            var entryKey = rows.FirstOrDefault()?.IssueUrl;
            var issueKey = rows.FirstOrDefault()?.IssueId;

            if (string.IsNullOrWhiteSpace(entryKey) || string.IsNullOrWhiteSpace(issueKey))
                return false;

            if (!rows.All(e => string.Equals(e.IssueUrl, entryKey) && string.Equals(e.IssueId, issueKey)))
                throw new ArgumentException("Invalid row set. There are entries with different issues.");

            return true;
        }

        #endregion

    }
}