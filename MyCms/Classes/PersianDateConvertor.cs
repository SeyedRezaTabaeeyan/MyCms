using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MyCms
{
    public static class PersianDateConvertor
    {
        public static string ToShamsi(this DateTime date)
        {
            PersianCalendar pc=new PersianCalendar();
            return pc.GetYear(date) + "/" + pc.GetMonth(date).ToString("00")  + "/" + pc.GetDayOfMonth(date).ToString("00");
        }
    }
}