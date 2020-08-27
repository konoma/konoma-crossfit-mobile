using System.Threading.Tasks;
using UIKit;

namespace Konoma.CrossFit.Helpers
{
    public class Prompt
    {
        public static Task<PromptResult> ShowPromptAsync(PromptConfig prompt, UIViewController parentController)
        {
            var taskCompletionSource = new TaskCompletionSource<PromptResult>();

            var alertController = UIAlertController.Create(prompt.Title, prompt.Message, UIAlertControllerStyle.Alert);

            alertController.AddTextField(textField =>
            {
                textField.Placeholder = prompt.Placeholder;
                textField.Text = prompt.Text;
            });
            alertController.AddAction(UIAlertAction.Create(prompt.OkText, UIAlertActionStyle.Default, alert => taskCompletionSource.SetResult(PromptResult.Result(alertController.TextFields[0].Text))));
            alertController.AddAction(UIAlertAction.Create(prompt.CancelText, UIAlertActionStyle.Cancel, alert => taskCompletionSource.SetResult(PromptResult.Cancelled())));

            parentController.PresentViewController(alertController, true, null);

            return taskCompletionSource.Task;
        }

    }
}
