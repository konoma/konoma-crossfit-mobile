
using System;
using Konoma.CrossFit;
using Sample.Core;
using UIKit;

namespace Sample.iOS
{
    public partial class ViewController : UIViewController
    {
        private ViewModel ViewModel;

        protected ViewController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            PlatformContext.Shared.Initialize(null);
            this.ViewModel = new ViewModel();

            // Perform any additional setup after loading the view, typically from a nib.
            Button.AccessibilityIdentifier = "myButton";
            Button.TouchUpInside += delegate
            {
                var title = string.Format("{0} clicks!", this.ViewModel.IncreaseCounter());
                Button.SetTitle(title, UIControlState.Normal);
            };
        }
    }
}
