using System;
using Konoma.Ui;
using UIKit;

namespace Sample.iOS
{
    public class PrimaryButton : Button
    {
        public PrimaryButton()
        {
            this.SetBackgroundColor(UIColor.SystemBlueColor, UIControlState.Normal);
            this.SetBackgroundColor(UIColor.SystemBlueColor.ColorWithAlpha(0.5f), UIControlState.Highlighted);

            this.CornerRadius = CornerRadius.Continuous(6.0f);
            this.Padding = Insets.All(8.0f);
        }
    }
}
