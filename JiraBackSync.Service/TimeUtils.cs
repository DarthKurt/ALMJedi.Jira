using System;
using System.Globalization;
using JiraBackSync.Core.Utils;
using JiraBackSync.Service.Configuration;
using Microsoft.Extensions.Options;

namespace JiraBackSync.Service
{
    internal class TimeUtils: ITimeUtils
    {
        private readonly TimeUtilsOptions _config;

        public TimeUtils(IOptions<TimeUtilsOptions> config)
        {
            _config = config.Value;
            StartOfWeek = CalcStartOfWeek(Now.Date.AddDays(_config.WorkingWeekOffset * 7),
                CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);

            EndOfWeek = CalcEndOfWeek(Now.Date.AddDays(_config.WorkingWeekOffset * 7),
                CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
        }

        private static DateTime CalcStartOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            var diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }
            return dt.AddDays(-1 * diff).Date;
        }

        private static DateTime CalcEndOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            var nextWeekDate = dt.AddDays(7);
            var nextWeekStartDate = CalcStartOfWeek(nextWeekDate, startOfWeek);

            return nextWeekStartDate.AddTicks(-1);
        }

        public DateTime Now => DateTime.Now.Add(_config.DebugOffset);
        public DateTime StartOfWeek { get; }
        public DateTime EndOfWeek { get; }
    }
}