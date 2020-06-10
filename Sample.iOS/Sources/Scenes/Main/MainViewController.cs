using System;
using Konoma.CrossFit;
using Sample.Core;
using UIKit;

namespace Sample.iOS
{
    public class MainViewController : SceneScreenViewController<MainScene>, IMainScreen
    {
        #region Events

        public event EventHandler? Created;

        #endregion

        #region User Interface

        public override void LoadView()
        {
            this.View = new UILabel
            {
                BackgroundColor = UIColor.Magenta,
                TextColor = UIColor.Yellow,
                Text = "Hello, World!",
                TextAlignment = UITextAlignment.Center,
            };
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.Created?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}
