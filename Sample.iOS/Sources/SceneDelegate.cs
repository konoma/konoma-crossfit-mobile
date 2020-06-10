using Foundation;
using Konoma.CrossFit;
using Sample.Core;
using UIKit;

namespace Sample.iOS
{
    [Register("SceneDelegate")]
    public class SceneDelegate : UIResponder, IUIWindowSceneDelegate
    {
        [Export("window")]
        public UIWindow Window { get; set; } = null!;

        [Export("scene:willConnectToSession:options:")]
        public void WillConnect(UIScene scene, UISceneSession session, UISceneConnectionOptions connectionOptions)
        {
            if (!(scene is UIWindowScene windowScene)) return;

            this.Window = new UIWindow(windowScene);

            this.ShowUserInterface();
        }

        private void ShowUserInterface()
        {
            var app = SampleApp.Setup(setup =>
            {
                // Add platform dependencies here
            });

            Navigator.NavigateRoot(this.Window, new MainScene(app.Coordinator), new MainViewController());

            this.Window.MakeKeyAndVisible();
        }
    }
}
