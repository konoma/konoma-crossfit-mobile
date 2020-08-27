using System.Threading.Tasks;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.Fragment.App;
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
                this.Scene = Scenes.Get<TScene>(this, savedInstanceState, null);
            }
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);

            Scenes.Persist(this.Scene, outState);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            if (this.IsRemoving || this.Activity.IsFinishing)
            {
                this.Scene.Disconnect();
                Scenes.Destroy(this.Scene);
            }
        }

        #region AlertPrompt

        public Task<PromptResult> ShowPromptAsync(PromptConfig prompt) => Prompt.ShowPromptAsync(prompt, this.Context);

        #endregion
    }
}
