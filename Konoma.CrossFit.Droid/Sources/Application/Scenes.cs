using System;
using System.Collections.Generic;
using Android.Content;
using Android.OS;

namespace Konoma.CrossFit
{
    public static class Scenes
    {
        private static readonly IDictionary<string, Scene> PersistedScenes = new Dictionary<string, Scene>();
        private const string IdentifierKey = "Konoma.Modular::SceneIdentifier";

        public static TScene? TryGet<TScene>(
            ISceneScreen screen,
            Bundle? savedInstanceState,
            Intent? intent,
            string? launchId = null
        )
            where TScene : Scene
        {
            var scene = Retrieve<TScene>(savedInstanceState?.GetString(IdentifierKey))
                ?? Retrieve<TScene>(intent?.GetStringExtra(IdentifierKey))
                ?? Retrieve<TScene>(GetLaunchKey(typeof(TScene), launchId));

            scene?.Connect(screen);
            return scene;
        }

        public static TSceneScreen SetupFragment<TScene, TSceneScreen>(
            TScene scene,
            TSceneScreen screen
        )
            where TScene : Scene
            where TSceneScreen : SceneScreenFragment<TScene>
        {
            screen.SetScene(scene);
            scene.Connect(screen);
            return screen;
        }

        private static TScene? Retrieve<TScene>(string? key) where TScene : Scene
        {
            if (key == null)
            {
                return null;
            }

            if (!PersistedScenes.TryGetValue(key, out var scene))
            {
                return null;
            }

            PersistedScenes.Remove(key);
            return (TScene)scene;
        }

        public static void Persist(Scene scene, Bundle? savedInstanceState)
        {
            if (savedInstanceState == null)
            {
                return;
            }

            PersistedScenes[scene.Identifier] = scene;
            savedInstanceState.PutString(IdentifierKey, scene.Identifier);
        }

        public static void Persist(Scene scene, Intent intent)
        {
            PersistedScenes[scene.Identifier] = scene;
            intent.PutExtra(IdentifierKey, scene.Identifier);
        }

        public static void PersistLaunchScene<TScene>(TScene scene, string? id = null) where TScene : Scene
        {
            PersistedScenes[GetLaunchKey(typeof(TScene), id)] = scene;
        }

        public static void Destroy(Scene scene)
        {
            PersistedScenes.Remove(scene.Identifier);
        }

        private static string GetLaunchKey(Type sceneType, string? id) => $"LaunchScene-{sceneType.FullName}-{id ?? ""}";
    }
}
