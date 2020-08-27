using System;
using System.Threading.Tasks;
using CoreFoundation;
using Foundation;
using Konoma.CrossFit.Helpers;
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

        ~SceneScreenViewController()
        {
            this.DisconnectFromScene();
        }

        void ISceneScreenViewController<TScene>.SetScene(TScene scene)
        {
            this.Scene = scene;
        }

        void ISceneScreenViewController<TScene>.SceneConnected() { }

        protected TScene Scene { get; private set; } = null!;

        private void DisconnectFromScene()
        {
            this.Scene?.Disconnect();
            this.Scene = null!;
        }

        #endregion

        #region View Lifecycle

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            if (this.IsBeingDismissed || this.IsMovingFromParentViewController)
            {
                DispatchQueue.MainQueue.DispatchAsync(() => this.DisconnectFromScene());
            }
        }

        #endregion

        #region AlertPrompt

        public Task<PromptResult> ShowPromptAsync(PromptConfig prompt) => Prompt.ShowPromptAsync(prompt, this);

        #endregion
    }
}
