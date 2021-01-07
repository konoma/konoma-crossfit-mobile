using System.Threading.Tasks;
using Android.OS;
using AndroidX.AppCompat.App;
using Konoma.CrossFit.Helpers;

namespace Konoma.CrossFit
{
    public abstract class SceneScreenAppCompatActivity<TScene> : AppCompatActivity, ISceneScreen where TScene : Scene
    {
        protected TScene Scene { get; private set; } = null!;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (Scenes.TryGet<TScene>(this, savedInstanceState, this.Intent) is TScene scene)
            {
                this.Scene = scene;
            }
            else
            {
                Finish();
            }
        }

        protected override void OnSaveInstanceState(Bundle? outState)
        {
            base.OnSaveInstanceState(outState);

            if (this.Scene != null)
            {
                Scenes.Persist(this.Scene, outState);
            }
        }

        public override void OnSaveInstanceState(Bundle? outState, PersistableBundle? outPersistentState)
        {
            base.OnSaveInstanceState(outState, outPersistentState);

            if (this.Scene != null)
            {
                Scenes.Persist(this.Scene, outState);
            }
        }

        protected override void OnDestroy()
        {
            if (this.IsFinishing && this.Scene is Scene scene)
            {
                scene.Disconnect();
                Scenes.Destroy(scene);

                this.Scene = null!;
            }

            base.OnDestroy();
        }


        #region Alert

        public Task<AlertPromptResult> ShowPromptAsync(AlertPromptConfig prompt) => Alert.ShowPromptAsync(prompt, this);
        public Task<AlertConfirmationResult> ShowConfirmationAsync(AlertConfirmationConfig confirmation) => Alert.ShowConfirmationAsync(confirmation, this);
        public Task ShowAlert(AlertMessageConfig alertConfig) => Alert.ShowAlertAsync(alertConfig, this);

        #endregion
    }
}
