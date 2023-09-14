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

        public static long DiscountCalc(long price, int discount)
        {
            var result = price * (100-discount) / 100;
            return result;
        }
    }
}