using System;
using Android.App;
using Android.Content;
using Android.OS;

namespace Konoma.CrossFit
{
    public static class Navigator
    {
        public static void Navigate<TScene>(Activity parentActivity, TScene scene, Type screenActivityType, Bundle? options = null) where TScene : Scene
        {
            var intent = new Intent(parentActivity, screenActivityType);
            Navigate(parentActivity, scene, intent, options);
        }

        public static void Navigate(Activity parentActivity, Scene scene, Intent intent, Bundle? options = null)
        {
            Scenes.Persist(scene, intent);
            parentActivity.StartActivity(intent, options);
        }
    }
}
