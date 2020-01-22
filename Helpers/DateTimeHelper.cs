using System;
using System.Globalization;

namespace DateTimeHelper
{
    public static class DateTimeHelper
    {

        #region "public methods"

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

        #endregion

    }
}