using CoreFoundation;
using Konoma.CrossFit.Helpers;

namespace Konoma.CrossFit
{
    public class SceneScreenTabBarController<TScene> : UITabBarController, ISceneScreen, ISceneScreenViewController<TScene> where TScene : Scene
    {
        #region Initialization

        public SceneScreenTabBarController(string nibName, NSBundle bundle) : base(nibName, bundle) { }
        public SceneScreenTabBarController(NSCoder coder) : base(coder) { }
        public SceneScreenTabBarController() { }

        protected SceneScreenTabBarController(IntPtr handle) : base(handle) { }
        protected SceneScreenTabBarController(NSObjectFlag t) : base(t) { }

        ~SceneScreenTabBarController()
        {
            this.DisconnectFromScene();
        }

        void ISceneScreenViewController<TScene>.SetScene(TScene scene)
        {
            this.Scene = scene;
        }

        void ISceneScreenViewController<TScene>.SceneConnected()
        {
            this.IsInitialized = true;
            this.TryConfigureView();
        }

        private void DisconnectFromScene()
        {
            this.Scene?.Disconnect();
            this.Scene = null!;
        }

        protected TScene Scene { get; private set; } = null!;
        private bool IsInitialized;

        // ViewDidLoad is called directly in the superclass constructor, therefore this is dangerous to override
        // Override ConfigureView() instead
        //
        public sealed override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.TryConfigureView();
        }

        private void TryConfigureView()
        {
            if (this.IsInitialized && this.IsViewLoaded)
            {
                this.ConfigureView();
            }
        }

        protected virtual void ConfigureView() { }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            if (this.IsBeingDismissed || this.IsMovingFromParentViewController)
            {
                DispatchQueue.MainQueue.DispatchAsync(() => this.DisconnectFromScene());
            }
        }

        #endregion

        #region Alert

        public Task<AlertPromptResult> ShowPromptAsync(AlertPromptConfig prompt) => Alert.ShowPromptAsync(prompt, this);
        public Task<AlertConfirmationResult> ShowConfirmationAsync(AlertConfirmationConfig confirmation) => Alert.ShowConfirmationAsync(confirmation, this);
        public Task ShowAlert(AlertMessageConfig alertConfig) => Alert.ShowAlertAsync(alertConfig, this);

        #endregion
    }
}
