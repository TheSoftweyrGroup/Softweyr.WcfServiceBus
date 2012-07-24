namespace Softweyr.CrossCutting.Helpers
{
    using System;

    public static class Time
    {
        public static Func<DateTime> NowFunc = NowFunc = () => DateTime.Now;

        public static DateTime Today
        {
            get { return NowFunc().Date; }
        }

        public static DateTime Now
        {
            get { return NowFunc(); }
        }

        public static DateTime Tomorrow
        {
            get { return NowFunc().Date.AddDays(1); }
        }

        public static DateTime Yesterday
        {
            get { return NowFunc().Date.AddDays(-1); }
        }

        public static TimeSpan TimeOfDay
        {
            get { return NowFunc().TimeOfDay; }
        }

        public static DateTime MonthStart(DateTime date)
        {
            return date.AddDays(-(date.Day - 1)).Date;
        }

        public static DateTime MonthStart()
        {
            return MonthStart(NowFunc());
        }

        public static DateTime MonthEnd(DateTime date)
        {
            return MonthStart(date.AddMonths(1)).Date;
        }

        public static DateTime MonthEnd()
        {
            return MonthEnd(NowFunc());
        }
    }
}
