
using System;
using UIKit;

namespace Konoma.CrossFit
{
    public class DeviceInfo : IDeviceInfo
    {
        #region Initialization

        public DeviceInfo() : this(UIDevice.CurrentDevice) { }

        public DeviceInfo(UIDevice device)
        {
            this.PlatformVersion = new Version(device.SystemVersion);
        }

        #endregion

        #region Device Info

        public DevicePlatform Platform { get; } = DevicePlatform.iOS;

        public Version PlatformVersion { get; }

        #endregion
    }
}
