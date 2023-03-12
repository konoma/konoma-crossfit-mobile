namespace Konoma.CrossFit
{
    public static class Scenes
    {
        public static TSceneScreen Setup<TScene, TSceneScreen>(TScene scene, TSceneScreen screen)
            where TScene : Scene
            where TSceneScreen : UIViewController, ISceneScreen, ISceneScreenViewController<TScene>
        {
            screen.SetScene(scene);
            scene.Connect(screen);
            screen.SceneConnected();

            return screen;
        }
    }
}
