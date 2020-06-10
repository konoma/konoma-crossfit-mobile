using System;
using Konoma.Basics;
using Konoma.CrossFit;

namespace Sample.Core
{
    public class LeafScene : Scene<ILeafScreen>
    {
        #region Initialization

        public LeafScene(Coordinator coordinator) : base(coordinator)
        {
        }

        ~LeafScene()
        {
            Log.Info("LeafScene finalized");
        }

        protected override void Connected()
        {
            this.Screen.Created += this.Screen_Created;

            this.Screen.BackPressed += this.Screen_BackPressed;
        }

        #endregion

        #region Actions

        private void Screen_Created(object sender, EventArgs e)
        {
            this.Screen.SetContent("Hi there!");
        }

        private void Screen_BackPressed(object sender, EventArgs e)
        {
            this.Screen.NavigateBack();
        }

        #endregion
    }
}
