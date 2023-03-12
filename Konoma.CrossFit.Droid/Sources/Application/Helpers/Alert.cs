using Android.Content;
using Android.Views;

namespace Konoma.CrossFit.Helpers
{
    public class Alert
    {
        public static Task<AlertPromptResult> ShowPromptAsync(AlertPromptConfig prompt, Context context)
        {
            var taskCompletionSource = new TaskCompletionSource<AlertPromptResult>();

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
                .SetPositiveButton(prompt.OkText, (alert, args) => taskCompletionSource.SetResult(AlertPromptResult.Result(input.Text)))
                .SetNegativeButton(prompt.CancelText, (alert, args) => taskCompletionSource.SetResult(AlertPromptResult.Cancelled()));

            builder.Create();
            builder.Show();

            return taskCompletionSource.Task;
        }

        public static Task<AlertConfirmationResult> ShowConfirmationAsync(AlertConfirmationConfig prompt, Context context)
        {
            var taskCompletionSource = new TaskCompletionSource<AlertConfirmationResult>();
            var inputContainer = new FrameLayout(context);

            var builder = new AndroidX.AppCompat.App.AlertDialog.Builder(context);
            builder
                .SetTitle(prompt.Title)
                .SetMessage(prompt.Message)
                .SetView(inputContainer)
                .SetPositiveButton(prompt.OkText, (alert, args) => taskCompletionSource.SetResult(AlertConfirmationResult.Confirm()))
                .SetNegativeButton(prompt.CancelText, (alert, args) => taskCompletionSource.SetResult(AlertConfirmationResult.Reject()));

            builder.Create();
            builder.Show();

            return taskCompletionSource.Task;
        }

        public static Task ShowAlertAsync(AlertMessageConfig config, Context context)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();
            var inputContainer = new FrameLayout(context);

            var builder = new AndroidX.AppCompat.App.AlertDialog.Builder(context);
            builder
                .SetTitle(config.Title)
                .SetMessage(config.Message)
                .SetView(inputContainer)
                .SetPositiveButton(config.OkText, (alert, args) => taskCompletionSource.SetResult(true));

            builder.Create();
            builder.Show();

            return taskCompletionSource.Task;
        }
    }
}
