using System;

namespace Konoma.CrossFit
{
    public abstract class Scene
    {
        protected Scene(Coordinator coordinator)
        {
            this.Coordinator = coordinator;
        }

        public string Identifier { get; } = Guid.NewGuid().ToString();

        protected Coordinator Coordinator { get; }

        internal abstract void Connect(ISceneScreen screen);
    }

    public abstract class Scene<TSceneScreen> : Scene where TSceneScreen : class, ISceneScreen
    {
        protected Scene(Coordinator coordinator) : base(coordinator) { }

        internal override void Connect(ISceneScreen screen)
        {
            this._Screen = new WeakReference<TSceneScreen>((TSceneScreen)screen);
            this.Connected();
        }

        private WeakReference<TSceneScreen> _Screen;
        protected TSceneScreen Screen => this._Screen.TryGetTarget(out var screen) ? screen : null;

        protected abstract void Connected();
    }

    public interface ISceneScreen { }
}
