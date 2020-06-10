using System;
using Konoma.CrossFit;

namespace Sample.Core
{
    public class MainScene : Scene<IMainScreen>
    {
        #region Initialization

        public MainScene(Coordinator coordinator) : base(coordinator)
        {
        }

        protected override void Connected()
        {
            this.Screen.Created += this.Screen_Created;
        }

        #endregion

        #region Actions

        private void Screen_Created(object sender, EventArgs e)
        {
            Console.WriteLine("Created");
        }

        #endregion
    }
}
