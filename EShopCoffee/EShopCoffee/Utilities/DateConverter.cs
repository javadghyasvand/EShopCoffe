using System;
using System.Globalization;

namespace MyShop.Utilities
{
    public static class DateConverter
    {
        public static string ToShamsi(this DateTime value )
        {
            PersianCalendar persian=new PersianCalendar();
            return persian.GetYear(value) + "/" + persian.GetMonth(value).ToString("00") + "/" +
                   persian.GetDayOfMonth(value).ToString("00");
        }
    }
}