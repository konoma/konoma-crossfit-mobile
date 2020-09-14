using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Konoma.CrossFit.Helpers;

namespace Konoma.CrossFit
{
    public class SceneScreenActivity<TScene> : Activity, ISceneScreen where TScene : Scene
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

            if (this.IsFinishing)
            {
                this.Scene.Disconnect();
                Scenes.Destroy(this.Scene);
            }
        }

        #region AlertPrompt

        public Task<PromptResult> ShowPromptAsync(PromptConfig prompt) => Prompt.ShowPromptAsync(prompt, this);

        #endregion

    }
}
