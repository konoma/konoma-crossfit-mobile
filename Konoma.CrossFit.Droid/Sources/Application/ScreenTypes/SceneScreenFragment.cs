using Android.OS;
using Android.Support.V4.App;

namespace Konoma.CrossFit
{
    public abstract class SceneScreenFragment<TScene> : Fragment, ISceneScreen where TScene : Scene
    {
        protected TScene Scene { get; private set; }

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
                Scenes.Destroy(this.Scene);
            }
        }
    }
}
