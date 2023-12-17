using System.Globalization;

public static class StringExtensions
{
    public static TimeSpan ToTimeSpan(this string timeString)
    {
        if (TimeSpan.TryParseExact(timeString, "hh\\:mm", CultureInfo.InvariantCulture, out TimeSpan result))
        {
            return result;
        }
        else
        {
            throw new FormatException("Formato de hora inválido");
        }
    }
}