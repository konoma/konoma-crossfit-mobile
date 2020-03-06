using System;
namespace Konoma.CrossFit
{
    public static class DeviceInformation
    {
        public static DeviceType DeviceType => throw new NotImplementedException("Must be shadowed by platform library");
        public static DevicePlatform DevicePlatform => throw new NotImplementedException("Must be shadowed by platform library");
        public static DeviceIdiom DeviceIdiom => throw new NotImplementedException("Must be shadowed by platform library");
    }

    public enum DeviceType
    {
        Physical,
        Virtual
    }

    public enum DevicePlatform
    {
        Android,
        iOS
    }

    public enum DeviceIdiom
    {
        Phone,
        Tablet,
        Unknown
    }
}
