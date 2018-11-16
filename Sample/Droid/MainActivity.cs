
using Android.App;
using Android.Widget;
using Android.OS;
using Konoma.CrossFit;
using Sample.Core;

namespace Sample.Droid
{
    [Activity(Label = "CrossFitSample", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private ViewModel ViewModel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            CrossFit.Shared.Initialize(null);

            this.ViewModel = new ViewModel();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += delegate { button.Text = $"{this.ViewModel.IncreaseCounter()} clicks!"; };
        }
    }
}
