using System;
using Foundation;
using UIKit;

namespace Konoma.CrossFit
{
    public class SceneScreenViewController<TScene> : UIViewController, ISceneScreen, ISceneScreenViewController<TScene> where TScene : Scene
    {
        #region Initialization

        public SceneScreenViewController(string nibName, NSBundle bundle) : base(nibName, bundle) { }
        public SceneScreenViewController(NSCoder coder) : base(coder) { }
        public SceneScreenViewController() { }

        protected SceneScreenViewController(IntPtr handle) : base(handle) { }
        protected SceneScreenViewController(NSObjectFlag t) : base(t) { }

        void ISceneScreenViewController<TScene>.SetScene(TScene scene)
        {
            this.Scene = scene;
        }

        void ISceneScreenViewController<TScene>.SceneConnected() { }

        protected TScene Scene { get; private set; } = null!;

        #endregion
    }
}
