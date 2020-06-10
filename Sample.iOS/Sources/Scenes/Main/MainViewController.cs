using System;
using Konoma.CrossFit;
using Konoma.Ui;
using Sample.Core;
using UIKit;

namespace Sample.iOS
{
    public class MainViewController : SceneScreenViewController<MainScene>, IMainScreen
    {
        #region Events

        public event EventHandler? Created;

        public event EventHandler? GarbageCollectorPressed;

        public event EventHandler? OpenModalPressed;

        #endregion

        #region Actions

        public void SetLabels(MainSceneLabels labels)
        {
            this.GarbageCollectorButton.Text = labels.GarbageCollectorButton;
            this.OpenModalButton.Text = labels.OpenModalButton;
        }

        #endregion

        #region User Interface

        private PrimaryButton GarbageCollectorButton = null!;
        private PrimaryButton OpenModalButton = null!;

        public override void LoadView()
        {
            this.View = new StackLayout.Vertical
            {
                BackgroundColor = UIColor.SystemBackgroundColor,

                Padding = Insets.All(16.0f),
                Spacing = 8.0f,

                Children =
                {
                    (this.GarbageCollectorButton = new PrimaryButton()),
                    new Spacer(16.0f),
                    (this.OpenModalButton = new PrimaryButton()),
                    new Spacer(),
                },
            };
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.GarbageCollectorButton.PrimaryActionTriggered += (sender, e) => this.GarbageCollectorPressed?.Invoke(this, EventArgs.Empty);
            this.OpenModalButton.PrimaryActionTriggered += (sender, e) => this.OpenModalPressed?.Invoke(this, EventArgs.Empty);

            this.Created?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}
