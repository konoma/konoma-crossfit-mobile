
using System;
using Android.OS;

namespace Konoma.CrossFit
{
    public class DeviceInfo : IDeviceInfo
    {
        #region Initialization

        public DeviceInfo()
        {
            this.PlatformVersion = new Version((int)Build.VERSION.SdkInt, 0);
            this.PhysicalDevice = !(Build.Fingerprint.Contains("vbox") || Build.Fingerprint.Contains("generic"));
        }

        #endregion

        #region Device Info

        public DevicePlatform Platform { get; } = DevicePlatform.Android;
        public Version PlatformVersion { get; }
        public bool PhysicalDevice { get; }

        #endregion
    }
}
