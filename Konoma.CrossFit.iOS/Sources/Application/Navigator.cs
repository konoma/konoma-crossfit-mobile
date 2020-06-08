using System;
using CoreFoundation;
using UIKit;

namespace Konoma.CrossFit
{
    public static class Navigator
    {
        public static void NavigateDetail<TScene, TSceneScreen>(UIViewController parentController, TScene scene, TSceneScreen screen)
            where TScene : Scene
            where TSceneScreen : UIViewController, ISceneScreen, ISceneScreenViewController<TScene>
        {
            var navigationController = parentController as UINavigationController ?? parentController.NavigationController;
            navigationController.PushViewController(Scenes.Setup(scene, screen), true);
        }

        public static void NavigateModal<TScene, TSceneScreen>(UIViewController parentController, TScene scene, TSceneScreen screen, Func<TSceneScreen, UIViewController>? wrapper = default)
            where TScene : Scene
            where TSceneScreen : UIViewController, ISceneScreen, ISceneScreenViewController<TScene>
        {
            Scenes.Setup(scene, screen);

            var controller = wrapper != null ? wrapper(screen) : screen;

            // Dispatch on main queue needed as a workaround for a bug in Xamarin:
            // https://bugzilla.xamarin.com/show_bug.cgi?id=47748
            DispatchQueue.MainQueue.DispatchAsync(() =>
                parentController.PresentViewController(controller, true, null)
            );
        }
    }
}
