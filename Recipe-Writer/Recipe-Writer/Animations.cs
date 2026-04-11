/// <file>Animations.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.4</version>
/// <date>April 12th 2026</date>

using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Recipe_Writer
{
    /// <summary>
    /// Handles the animation of the side menu
    /// Adapted from this source : https://stackoverflow.com/questions/6102241/how-can-i-add-moving-effects-to-my-controls-in-c
    /// </summary>
    public class Animations
    {
        // Import the AnimateWindow function from user32.dll
        [DllImport("user32.dll")]

        // IntPtr handle: Handle to the window to animate
        // int msec: Duration of the animation in milliseconds
        // int flags: Animation type and direction flags
        private static extern bool AnimateWindow(IntPtr handle, int msec, int flags);

        // Maps angles to direction directionFlags for AnimateWindow :
        // 1 = left, 2 = right, 4 = top, 8 = bottom
        private static int[] dirmap = { 1, 5, 4, 6, 2, 10, 8, 9 };

        // Maps Effect enum values to AnimateWindow directionFlags :
        // 0x40000 = hide, 0x80000 = show, 0x10 = center, 0x10000 = activate, 0x20000 = hide when minimized
        private static int[] effmap = { 0, 0x40000, 0x10, 0x80000 };
        
        public enum Effect { Roll, Slide, Center, Blend }

        /// <summary>
        /// Animates the showing or hiding of a control using the specified effect, duration, and angle.
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="effect"></param>
        /// <param name="msec"></param>
        /// <param name="angle"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public static void Animate(Control ctl, Effect effect, int msec, int angle)
        {
            // Get the base directionFlags for the specified effect
            int directionFlags = effmap[(int)effect];
            
            // If the control is currently visible, we want to hide it,
            // so we set the hide flag and adjust the angle for hiding
            if (ctl.Visible) 
            {
                directionFlags |= 0x10000; angle += 180; }
            else
            {
                // If the control is not visible, we want to show it.
                // If it's a top-level control, we set the hide when minimized flag.
                if (ctl.TopLevelControl == ctl)
                {
                    directionFlags |= 0x20000;
                }

                // The Blend effect is not supported for showing controls,
                // so we throw an exception if it's selected.
                else if (effect == Effect.Blend)
                {
                    throw new ArgumentException();
                }
            }

            // Converts the angle into one of the 8 primary directions (every 45°),
            // then retrieve the corresponding AnimateWindow direction flags.
            // dirmap maps each 45° sector to the correct combination of flags:
            // 0°=1 (left), 45°=5 (left+top), 90°=4 (top), 135°=6 (top+right),
            // 180°=2 (right), 225°=10 (right+bottom), 270°=8 (bottom), 315°=9 (bottom+left).
            directionFlags |= dirmap[(angle % 360) / 45];

            // AnimateWindow returns false if it fails, for example
            // if the control is not visible when trying to hide it
            bool animOk = AnimateWindow(ctl.Handle, msec, directionFlags);

            if (!animOk)
            {
                throw new Exception("Animation failed");
            }
            
            ctl.Visible = !ctl.Visible;
        }

    }
}
