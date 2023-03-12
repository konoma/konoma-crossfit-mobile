using AndroidX.AppCompat.App;
using Konoma.CrossFit.Helpers;

namespace Konoma.CrossFit
{
    public abstract class SceneScreenFragment<TScene> : Fragment, ISceneScreen where TScene : Scene
    {
        protected TScene Scene { get; private set; } = null!;

        protected AppCompatActivity AppCompatActivity => (AppCompatActivity)this.Activity;

        internal void SetScene(TScene scene)
        {
            this.Scene = scene;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (this.Scene == null)
            {
                if (Scenes.TryGet<TScene>(this, savedInstanceState, null) is TScene scene)
                {
                    this.Scene = scene;
                }
                else
                {
                    Activity.Finish();
                }
            }
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);

            if (this.Scene != null)
            {
                Scenes.Persist(this.Scene, outState);
            }
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            if ((this.IsRemoving || this.Activity.IsFinishing) && this.Scene != null)
            {
                this.Scene.Disconnect();
                Scenes.Destroy(this.Scene);

                this.Scene = null!;
            }
        }

        #region Alert

        public Task<AlertPromptResult> ShowPromptAsync(AlertPromptConfig prompt) => Alert.ShowPromptAsync(prompt, this.Context);
        public Task<AlertConfirmationResult> ShowConfirmationAsync(AlertConfirmationConfig confirmation) => Alert.ShowConfirmationAsync(confirmation, this.Context);
        public Task ShowAlert(AlertMessageConfig alertConfig) => Alert.ShowAlertAsync(alertConfig, this.Context);

        #endregion
    }
}
