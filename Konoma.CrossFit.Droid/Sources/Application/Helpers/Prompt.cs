using System.Threading.Tasks;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace Konoma.CrossFit.Helpers
{
    public class Prompt
    {
        public static Task<PromptResult> ShowPromptAsync(PromptConfig prompt, Context context)
        {
            var taskCompletionSource = new TaskCompletionSource<PromptResult>();

            var input = new EditText(context);
            input.Hint = prompt.Placeholder;
            input.Text = prompt.Text;
            input.SetSingleLine();

            var inputContainerParams = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            inputContainerParams.LeftMargin = 48; // no way to get the resourcedimen in pixels as there is no resource file
            inputContainerParams.RightMargin = inputContainerParams.LeftMargin;
            input.LayoutParameters = inputContainerParams;

            var inputContainer = new FrameLayout(context);
            inputContainer.AddView(input);

            var builder = new AndroidX.AppCompat.App.AlertDialog.Builder(context);
            builder
                .SetTitle(prompt.Title)
                .SetMessage(prompt.Message)
                .SetView(inputContainer)
                .SetPositiveButton(prompt.OkText, (alert, args) => taskCompletionSource.SetResult(PromptResult.Result(input.Text)))
                .SetNegativeButton(prompt.CancelText, (alert, args) => taskCompletionSource.SetResult(PromptResult.Cancelled()));

            builder.Create();
            builder.Show();

            return taskCompletionSource.Task;
        }

    }
}
