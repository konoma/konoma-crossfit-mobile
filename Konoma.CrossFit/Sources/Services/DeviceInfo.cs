
using System;

namespace Konoma.CrossFit
{
    public interface IDeviceInfo
    {
        DevicePlatform Platform { get; }
        Version PlatformVersion { get; }
        bool PhysicalDevice { get; }
    }

    public enum DevicePlatform
    {
        Android,
        iOS
    }

    public static class DeviceInfoExtensions
    {
        public static bool Check(this IDeviceInfo deviceInfo, DevicePlatform platform, Version minVersion = null)
        {
            if (deviceInfo.Platform != platform) { return false; }
            if (minVersion != null && deviceInfo.PlatformVersion < minVersion) { return false; }

            return true;
        }
    }

    public static class DeviceInfoContextExtensions
    {
        public static IDeviceInfo GetDeviceInfo(this PlatformContext context) => context.GetService<IDeviceInfo>();
    }
}
