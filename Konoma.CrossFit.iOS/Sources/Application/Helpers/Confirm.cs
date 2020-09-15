using System.Threading.Tasks;
using UIKit;

namespace Konoma.CrossFit.Helpers
{
    class Confirm
    {
        public static Task<ConfirmationResult> ShowPromptAsync(ConfirmationConfig prompt, UIViewController parentController)
        {
            var taskCompletionSource = new TaskCompletionSource<ConfirmationResult>();

            var alertController = UIAlertController.Create(prompt.Title, prompt.Message, UIAlertControllerStyle.Alert);
            alertController.AddAction(UIAlertAction.Create(prompt.OkText, UIAlertActionStyle.Default, alert => taskCompletionSource.SetResult(ConfirmationResult.Confirm())));
            alertController.AddAction(UIAlertAction.Create(prompt.CancelText, UIAlertActionStyle.Cancel, alert => taskCompletionSource.SetResult(ConfirmationResult.Reject())));

            parentController.PresentViewController(alertController, true, null);

            return taskCompletionSource.Task;
        }
    }
}
