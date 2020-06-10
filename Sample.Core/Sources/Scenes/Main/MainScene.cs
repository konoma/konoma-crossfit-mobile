using System;
using Konoma.Basics;
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

            this.Screen.GarbageCollectorPressed += this.Screen_GarbageCollectorPressed;
            this.Screen.OpenModalPressed += this.Screen_OpenModalPressed;
        }

        #endregion

        #region Actions

        private void Screen_Created(object sender, EventArgs e)
        {
            this.Screen.SetLabels(new MainSceneLabels());
        }

        private void Screen_GarbageCollectorPressed(object sender, EventArgs e)
        {
            Log.Info("Running Garbage Collector");

            GC.Collect();

            Log.Info("Garbage Collection Done");
        }

        private void Screen_OpenModalPressed(object sender, EventArgs e)
        {
            Log.Info("Open Modal");
        }

        #endregion
    }
}
