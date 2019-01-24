using System;
using System.Globalization;

namespace jetDev.PersianDate
{
    public static class Base
    {
        public static string GetDateOfWeek(string hijriDate)
        {
            int year;
            int month;
            int day;
            if (hijriDate.Length == 10)
            {
                     year   = int.Parse(hijriDate.Substring(0, 4));
             month = int.Parse(hijriDate.Substring(5, 2));
             day = int.Parse(hijriDate.Substring(8, 2)); 
            }
            else if (hijriDate.Length == 8)
            {
                year = int.Parse(hijriDate.Substring(0, 4));
                month = int.Parse(hijriDate.Substring(4, 2));
                day = int.Parse(hijriDate.Substring(6, 2));
            }
            else if (string.IsNullOrEmpty(hijriDate))
            {
                throw new ArgumentNullException("hijriDate Passed Date is null.");
            }
            else

            {
                throw new IndexOutOfRangeException("hijriDate  Passed Date is Not in CorrectFormat ");
            }



          

            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            var dayOfWeek = p.ToDateTime(year, month, day, 0, 0, 0, 0).DayOfWeek;
            switch (dayOfWeek.ToString().ToLower())
            {
                case "saturday":
                    return "شنبه";
                case "sunday":
                    return "یکشنبه";
                case "monday":
                    return "دوشنبه";
                case "tuesday":
                    return "سه شنبه";
                case "wednesday":
                    return "چهارشنبه";
                case "thursday":
                    return "پنجشنبه";
                case "friday":
                    return "جمعه";
                default:
                    return "نامعلوم";
            }
        }

        public static string Hijri(DateTime dateTime)
        {
            var pc = new PersianCalendar();
            return $"{pc.GetYear(dateTime):d4}/{pc.GetMonth(dateTime):d2}/{pc.GetDayOfMonth(dateTime):d2}";


        }

        public static DateTime Gregorian(string hijriDate)
        {


            int year;
            int month;
            int day;
            if (hijriDate.Length == 10)
            {
                year = int.Parse(hijriDate.Substring(0, 4));
                month = int.Parse(hijriDate.Substring(5, 2));
                day = int.Parse(hijriDate.Substring(8, 2));
            }
            else if (hijriDate.Length == 8)
            {
                year = int.Parse(hijriDate.Substring(0, 4));
                month = int.Parse(hijriDate.Substring(4, 2));
                day = int.Parse(hijriDate.Substring(6, 2));
            }
            else if (string.IsNullOrEmpty(hijriDate))
            {
                throw new ArgumentNullException("hijriDate Passed Date is null.");
            }
            else

            {
                throw new IndexOutOfRangeException("hijriDate  Passed Date is Not in CorrectFormat ");
            }
           System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            return p.ToDateTime(year, month, day, 0, 0, 0, 0);
        }


        public static int HijriMonthDays(string hijriDate)
        {
            int year;
            int month;
            if (hijriDate.Length == 10)
            {
                year = int.Parse(hijriDate.Substring(0, 4));
                month = int.Parse(hijriDate.Substring(5, 2));
            }
            else if (hijriDate.Length == 8)
            {
                year = int.Parse(hijriDate.Substring(0, 4));
                month = int.Parse(hijriDate.Substring(4, 2));
            }
            else if (string.IsNullOrEmpty(hijriDate))
            {
                throw new ArgumentNullException("hijriDate Passed Date is null.");
            }
            else

            {
                throw new IndexOutOfRangeException("hijriDate  Passed Date is Not in CorrectFormat ");
            }
            if (month > 0 && month < 7)
                return 31;
            if (month > 6 && month < 12)
                return 30;
            if (month == 12)
                return 29 +  Kabise(year) -  Kabise(year - 1);
            return 0;
        }
        private static int Kabise(int shamsi)
        {
            int num1 = shamsi - 508;
            int num2 = num1 / 128;
            int num3 = num1 % 128;
            int num4 = num3 / 33;
            int num5 = num3 % 33;
            return num2 * 31 + num4 * 8 + num5 / 4 - num3 / (int)sbyte.MaxValue - num5 / 32;
        }

        public static string AddDays(string hijriDate, int days)
        {
            DateTime date;
            date = Gregorian(hijriDate);
            date = date.AddDays(days);
            return Hijri(date);

        }

        public static string AddMonth(string hijriDate, int month)
        {
            DateTime date;
            date = Gregorian(hijriDate);
            date = date.AddMonths(month);
            return Hijri(date);
        }
    }
}