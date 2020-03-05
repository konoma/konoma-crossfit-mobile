using UIKit;

namespace Konoma.CrossFit
{
    public class DeviceInformationService : IDeviceInformationService
    {
        public DevicePlatform Platform => DevicePlatform.iOS;

        public DeviceIdiom Idiom => UIDevice.CurrentDevice.UserInterfaceIdiom switch
        {
            UIUserInterfaceIdiom.Phone => DeviceIdiom.Phone,
            UIUserInterfaceIdiom.Pad => DeviceIdiom.Tablet,

            _ => DeviceIdiom.Unknown
        };
    }
}
