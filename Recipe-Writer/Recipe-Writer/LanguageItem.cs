/// <file>LanguageItem.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.4</version>
/// <date>April 13th 2026</date>

using System;

namespace Recipe_Writer
{
    /// <summary>
    /// Represents a language entry for the ComboBox.
    /// DisplayName is localized through strings.resx.
    /// </summary>
    public class LanguageItem
    {
        public string DisplayName { get; set; }
        public string LanguageCode { get; set; }

        public LanguageItem(string displayName, string languageCode)
        {
            DisplayName = displayName;
            LanguageCode = languageCode;
        }
    }
}
