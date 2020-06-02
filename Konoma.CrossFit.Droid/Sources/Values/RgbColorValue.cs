using Android.Graphics;
using Android.Graphics.Drawables;

namespace Konoma.CrossFit
{
    public static class RgbColorValueExtensions
    {
        public static Color ToNativeColor(this RgbColorValue color) => new Color(
            r: color.Red,
            g: color.Green,
            b: color.Blue,
            a: color.Alpha);

        public static ColorDrawable ToNativeDrawable(this RgbColorValue color)
            => new ColorDrawable(color.ToNativeColor());
    }
}
