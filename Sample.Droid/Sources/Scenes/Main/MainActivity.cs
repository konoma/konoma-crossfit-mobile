using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Konoma.CrossFit;
using Sample.Core;

namespace Sample.Droid
{
    [Activity]
    public class MainActivity : SceneScreenAppCompatActivity<MainScene>, IMainScreen
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

        private Button GarbageCollectorButton = null!;
        private Button OpenModalButton = null!;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.SetContentView(Resource.Layout.main_activity);

            this.GarbageCollectorButton = this.FindViewById<Button>(Resource.Id.GarbageCollectorButton);
            this.GarbageCollectorButton.Click += (sender, e) => this.GarbageCollectorPressed?.Invoke(this, EventArgs.Empty);

            this.OpenModalButton = this.FindViewById<Button>(Resource.Id.OpenModalButton);
            this.OpenModalButton.Click += (sender, e) => this.OpenModalPressed?.Invoke(this, EventArgs.Empty);

            this.Created?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}
