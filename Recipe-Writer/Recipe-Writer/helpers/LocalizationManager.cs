/// <file>LocalizationManager.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.4</version>
/// <date>April 13th 2026</date>

using System;
using System.Globalization;
using System.Threading;

public static class LocalizationManager
{
    private static string _currentLanguageCode = "en";

    public static void SetLanguage(string languageCode)
    {
        if (string.IsNullOrWhiteSpace(languageCode))
        {
            languageCode = "en";
        }

        _currentLanguageCode = languageCode;

        CultureInfo culture = new CultureInfo(languageCode);
        Thread.CurrentThread.CurrentCulture = culture;
        Thread.CurrentThread.CurrentUICulture = culture;
    }

    public static string GetCurrentLanguageCode()
    {
        return _currentLanguageCode;
    }
}
