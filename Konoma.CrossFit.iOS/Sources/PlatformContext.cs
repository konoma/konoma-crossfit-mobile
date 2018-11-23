
using System;

namespace Konoma.CrossFit
{
    public static class PlatformContextExtensions
    {
        public static void Initialize(this PlatformContext context, Action<PlatformServiceRegistry> registrations)
        {
            var registry = context.ServiceRegistry;

            registrations?.Invoke(registry);

            context.Initialized = true;
        }
    }
}
