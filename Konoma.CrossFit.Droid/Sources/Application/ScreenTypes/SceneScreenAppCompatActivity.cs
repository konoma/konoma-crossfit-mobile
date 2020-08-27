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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.Scene = Scenes.Get<TScene>(this, savedInstanceState, this.Intent);
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);

            Scenes.Persist(this.Scene, outState);
        }

        public override void OnSaveInstanceState(Bundle outState, PersistableBundle outPersistentState)
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


        #region AlertPrompt

        public Task<string?> ShowPrompt(PromptConfig prompt) => Prompt.ShowPrompt(prompt, this);

        #endregion
    }
}
