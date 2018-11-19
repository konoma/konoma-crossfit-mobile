
using System;

namespace Konoma.CrossFit
{
    public class PlatformContext
    {
        #region Dependencies and State

        internal readonly PlatformServiceRegistry ServiceRegistry = new PlatformServiceRegistry();
        internal bool Initialized = false;

        #endregion

        #region Getting Services

        public TService GetService<TService>()
        {
            this.CheckInitialized();
            return this.ServiceRegistry.GetService<TService>();
        }

        private void CheckInitialized()
        {
            if (!this.Initialized)
            {
                throw new InvalidOperationException("CrossFit.Context must be initialized before it can be used");
            }
        }

        #endregion

        #region Shared Instance and Convenience

        public static PlatformContext Shared { get; } = new PlatformContext();

        #endregion
    }
}
