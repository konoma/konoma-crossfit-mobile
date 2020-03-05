
namespace Konoma.CrossFit
{
    public interface IDeviceInformationService
    {
        DevicePlatform Platform { get; }
        DeviceIdiom Idiom { get; }
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
