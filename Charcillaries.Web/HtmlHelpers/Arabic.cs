namespace Charcillaries.Web.HtmlHelpers;

public class Arabic
{
    public static string ConvertToArabicDigits(string input)
    {
        return input.Replace('0', '\u0660')
            .Replace('1', '\u0661')
            .Replace('2', '\u0662')
            .Replace('3', '\u0663')
            .Replace('4', '\u0664')
            .Replace('5', '\u0665')
            .Replace('6', '\u0666')
            .Replace('7', '\u0667')
            .Replace('8', '\u0668')
            .Replace('9', '\u0669')
            .Replace("AM", "ص")
            .Replace("PM", "م");
    }

    public static string ConvertToArabicDigits(int input)
    {
        return ConvertToArabicDigits(input.ToString());
    }

    public static string ConvertToArabicDigitsByCulture(string input, string culture)
    {
        return culture == "ar" ? ConvertToArabicDigits(input) : input;
    }

    public static string ConvertToArabicDigitsByCulture(int input, string culture)
    {
        return ConvertToArabicDigitsByCulture(input.ToString(), culture);
    }
}