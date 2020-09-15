using System.Threading.Tasks;
using Android.Content;
using Android.Widget;

namespace Konoma.CrossFit.Helpers
{
    class Confirm
    {
        public static Task<ConfirmationResult> ShowPromptAsync(ConfirmationConfig prompt, Context context)
        {
            var taskCompletionSource = new TaskCompletionSource<ConfirmationResult>();
            var inputContainer = new FrameLayout(context);
            
            var builder = new AndroidX.AppCompat.App.AlertDialog.Builder(context);
            builder
                .SetTitle(prompt.Title)
                .SetMessage(prompt.Message)
                .SetView(inputContainer)
                .SetPositiveButton(prompt.OkText, (alert, args) => taskCompletionSource.SetResult(ConfirmationResult.Confirm()))
                .SetNegativeButton(prompt.CancelText, (alert, args) => taskCompletionSource.SetResult(ConfirmationResult.Reject()));

            builder.Create();
            builder.Show();

            return taskCompletionSource.Task;
        }
    }
}
