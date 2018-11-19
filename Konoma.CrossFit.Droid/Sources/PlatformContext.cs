
using System;

namespace Konoma.CrossFit
{
    public static class PlatformContextExtensions
    {
        public static void Initialize(this PlatformContext context, Action<PlatformServiceRegistry> registrations)
        {
            var registry = context.ServiceRegistry;

            registry.RegisterService<IDeviceInfo>(() => new DeviceInfo());
            registry.RegisterService<IThreading>(() => new Threading());

            registrations?.Invoke(registry);

            context.Initialized = true;
        }
    }
}
