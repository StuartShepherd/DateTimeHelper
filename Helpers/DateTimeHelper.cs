using System;
using System.Globalization;

namespace DateTimeHelper
{
    public static class DateTimeHelper
    {

        #region "properties"

        public readonly static DateTime ZERO_TIME;

        #endregion

        #region "public methods"

        static DateTimeHelper()
        {
            DateTimeHelper.ZERO_TIME = DateTime.MinValue;
        }

        public static DateTime GetMinuteStart(DateTime date) => new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0);

        public static DateTime GetHourStart(DateTime date) => new DateTime(date.Year, date.Month, date.Day, date.Hour, 0, 0);

        public static DateTime GetDayStart(DateTime date) => new DateTime(date.Year, date.Month, date.Day);

        public static DateTime GetWeekStart(DateTime dayInWeek)
        {
            CultureInfo defaultCultureInfo = CultureInfo.CurrentCulture;
            return GetWeekStart(dayInWeek, defaultCultureInfo);
        }

        public static DateTime GetWeekStart(DateTime dayInWeek, CultureInfo cultureInfo)
        {
            DayOfWeek firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
            {
                firstDayInWeek = firstDayInWeek.AddDays(-1);
            }

            return firstDayInWeek;
        }

        public static DateTime GetMonthStart(DateTime date) => new DateTime(date.Year, date.Month, 1);

        public static DateTime GetYearStart(DateTime date) => new DateTime(date.Year, 1, 1);

        public static DayOfWeek GetFirstDayOfWeek()
        {
            CultureInfo defaultCultureInfo = CultureInfo.CurrentCulture;
            return DateTimeHelper.GetFirstDayOfWeek(defaultCultureInfo);
        }

        public static DayOfWeek GetFirstDayOfWeek(CultureInfo cultureInfo) => cultureInfo.DateTimeFormat.FirstDayOfWeek;

        public static int NumberOfWeeks(DateTime dateFrom, DateTime dateTo) => DateTimeHelper.NumberOfWeeks(dateFrom, dateTo, null);

        public static int NumberOfWeeks(DateTime dateFrom, DateTime dateTo, CultureInfo cultureInfo)
        {
            dateFrom = cultureInfo == null ? DateTimeHelper.GetWeekStart(dateFrom) : DateTimeHelper.GetWeekStart(dateFrom, cultureInfo);
            TimeSpan timeSpan = dateTo.Subtract(dateFrom);
            return 1 + timeSpan.Days / 7;
        }

        public static bool IsValidFromTo(DateTime from, DateTime to)
        {
            if (from <= to)
                return true;

            return to == DateTimeHelper.ZERO_TIME;
        }

        #endregion

    }
}