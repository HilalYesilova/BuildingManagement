namespace BuildingManagement.Service.Extensions;
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
