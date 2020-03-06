using UIKit;

namespace Konoma.CrossFit
{
    public static class DeviceInformation
    {
        public static DeviceType DeviceType => DeviceType.Physical;

        public static DevicePlatform DevicePlatform => DevicePlatform.iOS;

        public static DeviceIdiom DeviceIdiom => UIDevice.CurrentDevice.UserInterfaceIdiom switch
        {
            UIUserInterfaceIdiom.Phone => DeviceIdiom.Phone,
            UIUserInterfaceIdiom.Pad => DeviceIdiom.Tablet,

            _ => DeviceIdiom.Unknown
        };
    }
}
