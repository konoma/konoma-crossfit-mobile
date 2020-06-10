using Android.App;
using Android.OS;
using AndroidX.AppCompat.App;
using Konoma.CrossFit;
using Sample.Core;

namespace Sample.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, NoHistory = true)]
    public class LaunchActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var app = SampleApp.Setup(setup =>
            {
                // Add platform dependencies here
            });

            Navigator.Navigate(this, new MainScene(app.Coordinator), typeof(MainActivity));
        }
    }
}