﻿namespace SK.Framework;

public enum SupportedLanguage
{
    None,
    Arabic,
    English,
    German
}

public static class SupportedLanguageExtensions
{
    public static string Code(this SupportedLanguage self)
    {
        switch (self)
        {
            case SupportedLanguage.Arabic:
                return "ar";

            case SupportedLanguage.English:
                return "en";

            case SupportedLanguage.German:
                return "de";

            default: throw new ArgumentOutOfRangeException();
        }
    }

    public static SupportedLanguage ToSupportedLang(this string self)
    {
        switch (self)
        {
            case "ar": return SupportedLanguage.Arabic;
            case "en": return SupportedLanguage.English;
            case "de": return SupportedLanguage.German;
            default: throw new ArgumentOutOfRangeException();
        }
    }
}