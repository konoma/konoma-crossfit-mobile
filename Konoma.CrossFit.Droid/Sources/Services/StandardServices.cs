
namespace Konoma.CrossFit
{
    public static class StandardServicesRegistration
    {
        public static void RegisterStandardServices(this IServiceRegistry registry)
        {
            registry.RegisterStatic<IDeviceInformationService>(() => new DeviceInformationService());
        }
    }
}
