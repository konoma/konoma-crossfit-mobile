
using System;

namespace Konoma.CrossFit
{
    public class DeviceInfo
    {
        #region Initialization

        internal DeviceInfo(DevicePlatform platform, Version platformVersion, bool physicalDevice)
        {
            this.Platform = platform;
            this.PlatformVersion = platformVersion;
            this.PhysicalDevice = physicalDevice;
        }

        private static DeviceInfo _Current;

        public static DeviceInfo Current
        {
            get
            {
                if (_Current == null)
                {
                    var providerType = TypeLoader.LoadPlatformType("Konoma.CrossFit.DeviceInfoProvider");
                    var provider = (IDeviceInfoProvider)Activator.CreateInstance(providerType);
                    _Current = provider.GetDeviceInfo();
                }
                return _Current;
            }
        }

        #endregion

        #region Device Information

        public DevicePlatform Platform { get; }
        public Version PlatformVersion { get; }
        public bool PhysicalDevice { get; }

        public bool Check(DevicePlatform platform, Version minVersion = null)
        {
            if (this.Platform != platform) { return false; }
            if (minVersion != null && this.PlatformVersion < minVersion) { return false; }

            return true;
        }

        #endregion
    }

    internal interface IDeviceInfoProvider
    {
        DeviceInfo GetDeviceInfo();
    }

    public enum DevicePlatform
    {
        Android,
        iOS
    }
}
