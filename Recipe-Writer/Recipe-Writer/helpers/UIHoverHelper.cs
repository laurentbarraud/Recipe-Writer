/// <file>UIHoverHelper.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.4</version>
/// <date>April 10th 2026</date>

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Recipe_Writer.Properties;

public static class UIHoverHelper
{
    /// <summary>
    /// Maps each button to its base image resource name.
    /// </summary>
    public static readonly Dictionary<Button, string> ButtonBaseResourceNames
        = new Dictionary<Button, string>();

    /// <summary>
    /// Applies the hover version of the image.
    /// </summary>
    public static void Button_MouseEnter(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        string baseName;
        
        if (!ButtonBaseResourceNames.TryGetValue(btn, out baseName))
        {
            return;
        }

        Image hoverImage = Resources.ResourceManager.GetObject(baseName + "_hover") as Image;

        if (hoverImage != null)
        {
            btn.BackgroundImage = hoverImage;
        }
    }

    /// <summary>
    /// Restores the normal image.
    /// </summary>
    public static void Button_MouseLeave(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        string baseName;
        
        if (!ButtonBaseResourceNames.TryGetValue(btn, out baseName))
        {
            return;
        }

        Image normalImage = Resources.ResourceManager.GetObject(baseName) as Image;

        if (normalImage != null)
        {
            btn.BackgroundImage = normalImage;
        }
    }
}
