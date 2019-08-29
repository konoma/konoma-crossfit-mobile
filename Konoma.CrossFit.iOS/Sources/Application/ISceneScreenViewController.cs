
namespace Konoma.CrossFit
{
    public interface ISceneScreenViewController<TScene> where TScene : Scene
    {
        void SetScene(TScene scene);
        void SceneConnected();
    }
}
