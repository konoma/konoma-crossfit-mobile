
using System;
using Android.OS;

namespace Konoma.CrossFit
{
    public class DeviceInfoProvider : IDeviceInfoProvider
    {
        public DeviceInfo GetDeviceInfo()
        {
            return new DeviceInfo(
                platform: DevicePlatform.Android,
                platformVersion: new Version((int)Build.VERSION.SdkInt, 0),
                physicalDevice: !(Build.Fingerprint.Contains("vbox") || Build.Fingerprint.Contains("generic"))
            );
        }
    }
}
