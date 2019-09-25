using System;
using System.Threading.Tasks;

namespace Konoma.CrossFit
{
    public sealed class Coordinator
    {
        #region Initialization

        public static Coordinator Create(Action<CoordinatorSetup> setup)
        {
            var coordinator = new Coordinator();
            setup(new CoordinatorSetup(coordinator.ServiceRegistry));
            return coordinator;
        }

        public static async Task<Coordinator> CreateAsync(Func<CoordinatorSetup, Task> setup)
        {
            var coordinator = new Coordinator();
            await setup(new CoordinatorSetup(coordinator.ServiceRegistry));
            return coordinator;
        }

        private Coordinator() { }

        #endregion

        #region Dependencies

        private readonly ServiceRegistry ServiceRegistry = new ServiceRegistry();

        #endregion

        #region Coordinator

        public IServiceProvider Services => this.ServiceRegistry;

        #endregion
    }

    public class CoordinatorSetup
    {
        internal CoordinatorSetup(IServiceRegistry serviceRegistry)
        {
            this.Services = serviceRegistry;
        }

        public IServiceRegistry Services { get; }
    }
}
