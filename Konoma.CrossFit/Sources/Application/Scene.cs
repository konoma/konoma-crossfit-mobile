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

        internal abstract void Disconnect();
    }

    public abstract class Scene<TSceneScreen> : Scene where TSceneScreen : class, ISceneScreen
    {
        protected Scene(Coordinator coordinator) : base(coordinator) { }

        internal override void Connect(ISceneScreen screen)
        {
            this._Screen = new WeakReference<TSceneScreen>((TSceneScreen)screen);
            this.Connected();
        }

        internal override void Disconnect()
        {
            this.Disconnected();
            this._Screen = null;
        }

        private WeakReference<TSceneScreen>? _Screen = null;

        protected TSceneScreen Screen => this._Screen is WeakReference<TSceneScreen> screenRef && screenRef.TryGetTarget(out var screen)
            ? screen
            : throw new InvalidOperationException("Tried to read screen after it's not available anymore");

        protected abstract void Connected();

        protected virtual void Disconnected()
        {
        }
    }

    public interface ISceneScreen {

        public Task<AlertPromptResult> ShowPromptAsync(AlertPromptConfig prompt);
        public Task<AlertConfirmationResult> ShowConfirmationAsync(AlertConfirmationConfig confirmation);
        public Task ShowAlert(AlertMessageConfig alertConfig);
    }
}
