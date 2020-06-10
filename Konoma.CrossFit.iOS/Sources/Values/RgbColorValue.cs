using UIKit;

namespace Konoma.CrossFit
{
    public static class RgbColorValueExtensions
    {
        public static UIColor ToNativeColor(this RgbColorValue color) => new UIColor(
            red: color.Red / 255.0f,
            green: color.Green / 255.0f,
            blue: color.Blue / 255.0f,
            alpha: color.Alpha / 255.0f);
    }
}
