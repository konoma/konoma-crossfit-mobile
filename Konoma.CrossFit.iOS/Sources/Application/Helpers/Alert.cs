using System.Threading.Tasks;
using UIKit;

namespace Konoma.CrossFit.Helpers
{
    public class Alert
    {
        public static Task<AlertPromptResult> ShowPromptAsync(AlertPromptConfig prompt, UIViewController parentController)
        {
            var taskCompletionSource = new TaskCompletionSource<AlertPromptResult>();

            var alertController = UIAlertController.Create(prompt.Title, prompt.Message, UIAlertControllerStyle.Alert);

            alertController.AddTextField(textField =>
            {
                textField.Placeholder = prompt.Placeholder;
                textField.Text = prompt.Text;
            });
            alertController.AddAction(UIAlertAction.Create(prompt.OkText, UIAlertActionStyle.Default, alert => taskCompletionSource.SetResult(AlertPromptResult.Result(alertController.TextFields[0].Text))));
            alertController.AddAction(UIAlertAction.Create(prompt.CancelText, UIAlertActionStyle.Cancel, alert => taskCompletionSource.SetResult(AlertPromptResult.Cancelled())));

            parentController.PresentViewController(alertController, true, null);

            return taskCompletionSource.Task;
        }

        public static Task<AlertConfirmationResult> ShowConfirmationAsync(AlertConfirmationConfig prompt, UIViewController parentController)
        {
            var taskCompletionSource = new TaskCompletionSource<AlertConfirmationResult>();

            var alertController = UIAlertController.Create(prompt.Title, prompt.Message, UIAlertControllerStyle.Alert);
            alertController.AddAction(UIAlertAction.Create(prompt.OkText, UIAlertActionStyle.Default, alert => taskCompletionSource.SetResult(AlertConfirmationResult.Confirm())));
            alertController.AddAction(UIAlertAction.Create(prompt.CancelText, UIAlertActionStyle.Cancel, alert => taskCompletionSource.SetResult(AlertConfirmationResult.Reject())));

            parentController.PresentViewController(alertController, true, null);

            return taskCompletionSource.Task;
        }

        public static Task ShowAlertAsync(AlertMessageConfig config, UIViewController parentController)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();

            var alertController = UIAlertController.Create(config.Title, config.Message, UIAlertControllerStyle.Alert);
            alertController.AddAction(UIAlertAction.Create(config.OkText, UIAlertActionStyle.Default, alert => taskCompletionSource.SetResult(true)));

            parentController.PresentViewController(alertController, true, null);

            return taskCompletionSource.Task;
        }
    }
}
