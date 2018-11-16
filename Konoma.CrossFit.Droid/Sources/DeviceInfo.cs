
using System;

namespace Konoma.CrossFit
{
    public class DeviceInfo : IDeviceInfo
    {
        public DeviceInfo()
        {
            this.PlatformVersion = new Version((int)Android.OS.Build.VERSION.SdkInt, 0);
        }

        public DevicePlatform Platform { get; } = DevicePlatform.Android;

        public Version PlatformVersion { get; }
    }
}
