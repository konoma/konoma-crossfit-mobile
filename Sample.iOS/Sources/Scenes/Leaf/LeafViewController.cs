using System;
using Konoma.Basics;
using Konoma.CrossFit;
using Konoma.Ui;
using Sample.Core;
using UIKit;

namespace Sample.iOS
{
    public class LeafViewController : SceneScreenViewController<LeafScene>, ILeafScreen
    {
        #region Initialization

        ~LeafViewController()
        {
            Log.Info("LeafViewController finalized");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            Log.Info($"LeafViewController disposed (disposing: {disposing})");
        }

        #endregion

        #region Events

        public event EventHandler? Created;
        public event EventHandler? BackPressed;

        #endregion

        #region Actions

        public void SetContent(string content)
        {
            this.ContentTextView.Text = content;
        }

        #endregion

        #region Navigation

        public void NavigateBack() => this.DismissViewController(true, null);

        #endregion

        #region User Interface

        private Label ContentTextView => (Label)this.View;

        public override void LoadView()
        {
            this.View = new Label("", null)
            {
                BackgroundColor = UIColor.SystemBackgroundColor,
                TextColor = UIColor.LabelColor,

                Padding = Insets.All(16.0f)
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
