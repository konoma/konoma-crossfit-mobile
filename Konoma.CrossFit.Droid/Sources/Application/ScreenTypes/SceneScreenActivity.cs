using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace Konoma.CrossFit
{
    public class SceneScreenActivity<TScene> : Activity, ISceneScreen where TScene : Scene
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

            if (this.IsFinishing)
            {
                this.Scene.Disconnect();
                Scenes.Destroy(this.Scene);
            }
        }

        #region AlertPrompt

        public Task<string> ShowPrompt(PromptConfig prompt)
        {
            var taskCompletionSource = new TaskCompletionSource<string?>();

            var input = new EditText(this);
            input.Hint = prompt.Placeholder;
            input.Text = prompt.Text;
            input.SetSingleLine();

            var inputContainerParams = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            inputContainerParams.LeftMargin = 48; // no way to get the resourcedimen in pixels as there is no resource file
            inputContainerParams.RightMargin = inputContainerParams.LeftMargin;
            input.LayoutParameters = inputContainerParams;

            var inputContainer = new FrameLayout(this);
            inputContainer.AddView(input);

            var builder = new AndroidX.AppCompat.App.AlertDialog.Builder(this);
            builder
                .SetTitle(prompt.Title)
                .SetMessage(prompt.Message)
                .SetView(inputContainer)
                .SetPositiveButton(prompt.OkText, (alert, args) => taskCompletionSource.SetResult(input.Text))
                .SetNegativeButton(prompt.CancelText, (alert, args) => taskCompletionSource.SetResult(null));

            builder.Create();
            builder.Show();

            return taskCompletionSource.Task;
        }

        #endregion

    }
}
