using System;
using Android.App;
using Android.OS;
using Konoma.CrossFit;
using Sample.Core;

namespace Sample.Droid
{
    [Activity]
    public class MainActivity : SceneScreenAppCompatActivity<MainScene>, IMainScreen
    {
        #region Events

        public event EventHandler? Created;

        #endregion

        #region User Interface

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.SetContentView(Resource.Layout.main_activity);

            this.Created?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}
