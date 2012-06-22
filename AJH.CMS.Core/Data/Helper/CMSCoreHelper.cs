using System;

namespace AJH.CMS.Core.Data
{
    public static class CMSCoreHelper
    {
        #region DateTime

        const int RefDay = 1;
        const int RefMonth = 1;
        const int RefYear = 1990;
        static DateTime RefDateTime;

        static CMSCoreHelper()
        {
            RefDateTime = new DateTime(RefYear, RefMonth, RefDay);
        }

        public static bool GetDaySecondsNumber(DateTime dateTime, out double Days, out double Seconds)
        {
            try
            {
                TimeSpan timeSpanDay = dateTime - RefDateTime;
                Days = timeSpanDay.TotalDays;
                TimeSpan timeSpanSecond = dateTime - (new DateTime(dateTime.Year, dateTime.Month, dateTime.Day));
                Seconds = timeSpanSecond.TotalSeconds;
                return true;
            }
            catch
            {
                Days = 0;
                Seconds = 0;
                return false;
            }
        }

        public static DateTime GetDateTime(int Days, int Seconds)
        {
            DateTime dateTIme = RefDateTime.AddDays(Days);
            dateTIme = dateTIme.AddSeconds(Seconds);
            return dateTIme;
        }

        #endregion
    }
}