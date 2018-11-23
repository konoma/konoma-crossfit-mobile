
using System;
using UIKit;

namespace Konoma.CrossFit
{
    public class DeviceInfoProvider : IDeviceInfoProvider
    {
        public DeviceInfo GetDeviceInfo()
        {
            return new DeviceInfo(
                platform: DevicePlatform.iOS,
                platformVersion: new Version(UIDevice.CurrentDevice.SystemVersion),
                physicalDevice: ObjCRuntime.Runtime.Arch == ObjCRuntime.Arch.DEVICE
            );
        }
    }
}
