using System;
using System.Threading;
using System.Threading.Tasks;
using CoreFoundation;
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


        public Task<string> ShowPrompt(PromptConfig prompt)
        {
            var taskCompletionSource = new TaskCompletionSource<string?>();

            var alertController = UIAlertController.Create(prompt.Title, prompt.Message, UIAlertControllerStyle.Alert);

            alertController.AddTextField(textField =>
            {
                textField.Placeholder = prompt.Placeholder;
                textField.Text = prompt.Text;
            });
            alertController.AddAction(UIAlertAction.Create(prompt.OkText, UIAlertActionStyle.Default, alert => taskCompletionSource.SetResult(alertController.TextFields[0].Text)));
            alertController.AddAction(UIAlertAction.Create(prompt.CancelText, UIAlertActionStyle.Cancel, alert => taskCompletionSource.SetResult(null)));

            PresentViewController(alertController, true, null);

            return taskCompletionSource.Task;
        }

        #endregion
    }
}
