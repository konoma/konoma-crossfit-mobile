using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Konoma.Basics;
using Konoma.CrossFit;
using Sample.Core;

namespace Sample.Droid
{
    [Activity]
    public class LeafActivity : SceneScreenAppCompatActivity<LeafScene>, ILeafScreen
    {
        #region Initialization

        ~LeafActivity()
        {
            Log.Info("LeafActivity finalized");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            Log.Info($"LeafActivity disposed (disposing: {disposing})");
        }

        #endregion

        #region Events

        public event EventHandler? Created;
        public event EventHandler? BackPressed;

        #endregion

        #region Actions

        public void SetContent(string content)
        {
            this.FindViewById<TextView>(Resource.Id.ContentTextView).Text = content;
        }

        #endregion

        #region Navigation

        public void NavigateBack() => this.Finish();

        #endregion

        #region User Interface

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.SetContentView(Resource.Layout.leaf_activity);

            this.Created?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}
