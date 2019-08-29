using System;
using Android.App;
using Android.Content;

namespace Konoma.CrossFit
{
    public static class Navigator
    {
        public static void Navigate<TScene>(Activity parentActivity, TScene scene, Type screenActivityType)
            where TScene : Scene
        {
            var intent = new Intent(parentActivity, screenActivityType);
            Navigate(parentActivity, scene, intent);
        }

        public static void Navigate(Activity parentActivity, Scene scene, Intent intent)
        {
            Scenes.Persist(scene, intent);
            parentActivity.StartActivity(intent);
        }
    }
}
