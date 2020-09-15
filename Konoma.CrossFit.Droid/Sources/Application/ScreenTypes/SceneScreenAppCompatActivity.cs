using System.Threading.Tasks;
using Android.OS;
using Android.Views;
using Android.Widget;
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

            Scenes.Persist(this.Scene, outState);
        }

        public override void OnSaveInstanceState(Bundle? outState, PersistableBundle? outPersistentState)
        {
            base.OnSaveInstanceState(outState, outPersistentState);

            Scenes.Persist(this.Scene, outState);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            if (!this.IsChangingConfigurations)
            {
                this.Scene.Disconnect();
                Scenes.Destroy(this.Scene);
            }
        }


        #region Alert

        public Task<PromptResult> ShowPromptAsync(PromptConfig prompt) => Prompt.ShowPromptAsync(prompt, this);
        public Task<ConfirmationResult> ShowConfirmationAsync(ConfirmationConfig confirmation) => Confirm.ShowConfirmationAsync(confirmation, this);

        #endregion
    }
}
