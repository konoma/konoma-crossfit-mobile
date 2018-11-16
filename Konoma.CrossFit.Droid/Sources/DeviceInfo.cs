
using System;

namespace Konoma.CrossFit
{
    public class DeviceInfo : IDeviceInfo
    {
        #region Initialization

        public DeviceInfo()
        {
            this.PlatformVersion = new Version((int)Android.OS.Build.VERSION.SdkInt, 0);
        }

        #endregion

        #region Device Info

        public DevicePlatform Platform { get; } = DevicePlatform.Android;

        public Version PlatformVersion { get; }

        #endregion
    }
}
