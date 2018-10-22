using System;

namespace JiraBackSync.Core.Utils
{
    public interface ITimeUtils
    {
        DateTime Now { get; }

        DateTime StartOfWeek { get; }

        DateTime EndOfWeek { get; }
    }
}