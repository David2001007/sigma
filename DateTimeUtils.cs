using System;

public static class DateTimeUtils
{
    public static DateTime ConverterDHBrasilia(DateTime dataUtc)
    {
        var brasiliaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
        return TimeZoneInfo.ConvertTimeFromUtc(dataUtc, brasiliaTimeZone);
    }
}