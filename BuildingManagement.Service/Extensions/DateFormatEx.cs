using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Service.Extensions
{
    public static class DateFormatEx
    {
        public static string MonthFormat(this DateTime dateTime)
        {
            var month = dateTime.Month.ToString();
            if (month.ToString().Length < 2)
            {
                month = "0" + month.ToString();
            }
            return month;
        }
    }
}
