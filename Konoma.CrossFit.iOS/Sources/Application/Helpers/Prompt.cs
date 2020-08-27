using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace Konoma.CrossFit.Helpers
{
    class Prompt
    {
        public static Task<string?> ShowPrompt(PromptConfig prompt, UIViewController parentController)
        {
            var taskCompletionSource = new TaskCompletionSource<string?>();

            var alertController = UIAlertController.Create(prompt.Title, prompt.Message, UIAlertControllerStyle.Alert);

            alertController.AddTextField(textField =>
            {
                textField.Placeholder = prompt.Placeholder;
                textField.Text = prompt.Text;
            });
            alertController.AddAction(UIAlertAction.Create(prompt.OkText, UIAlertActionStyle.Default, alert => taskCompletionSource.SetResult(alertController.TextFields[0].Text)));
            alertController.AddAction(UIAlertAction.Create(prompt.CancelText, UIAlertActionStyle.Cancel, alert => taskCompletionSource.SetResult(null)));

            parentController.PresentViewController(alertController, true, null);

            return taskCompletionSource.Task;
        }

    }
}
