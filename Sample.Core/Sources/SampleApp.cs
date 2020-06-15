using System;
using Konoma.CrossFit;

namespace Sample.Core
{
    public class SampleApp
    {
        #region Initialization

        public static SampleApp Setup(Action<CoordinatorSetup> configure) => new SampleApp(Coordinator.Create(setup =>
        {
            // Platform agnostic setup

            // Platform specific setup
            configure(setup);
        }));

        private SampleApp(Coordinator coordinator)
        {
            this.Coordinator = coordinator;
        }

        #endregion

        #region Dependencies

        public Coordinator Coordinator { get; }

        #endregion
    }
}
