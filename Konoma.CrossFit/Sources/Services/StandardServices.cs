
namespace Konoma.CrossFit
{
    public static class StandardServices
    {
        public static IDeviceInformationService DeviceInformationService(this IServiceProvider provider)
            => provider.Get<IDeviceInformationService>();
    }
}
