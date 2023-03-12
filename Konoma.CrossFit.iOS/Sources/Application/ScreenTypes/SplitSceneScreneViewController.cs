using Konoma.CrossFit.Helpers;

namespace Konoma.CrossFit
{
    public class SplitSceneScreenViewController<TScene> : UISplitViewController, ISceneScreen, ISceneScreenViewController<TScene> where TScene : Scene
    {
        #region Initialization

        public SplitSceneScreenViewController(string nibName, NSBundle bundle) : base(nibName, bundle) { }
        public SplitSceneScreenViewController(NSCoder coder) : base(coder) { }
        public SplitSceneScreenViewController() { }

        protected SplitSceneScreenViewController(IntPtr handle) : base(handle) { }
        protected SplitSceneScreenViewController(NSObjectFlag t) : base(t) { }

        void ISceneScreenViewController<TScene>.SetScene(TScene scene)
        {
            this.Scene = scene;
        }

        void ISceneScreenViewController<TScene>.SceneConnected() { }

        protected TScene Scene { get; private set; } = null!;

        #endregion

        #region Alert

        public Task<AlertPromptResult> ShowPromptAsync(AlertPromptConfig prompt) => Alert.ShowPromptAsync(prompt, this);
        public Task<AlertConfirmationResult> ShowConfirmationAsync(AlertConfirmationConfig confirmation) => Alert.ShowConfirmationAsync(confirmation, this);
        public Task ShowAlert(AlertMessageConfig alertConfig) => Alert.ShowAlertAsync(alertConfig, this);

        #endregion
    }
}
