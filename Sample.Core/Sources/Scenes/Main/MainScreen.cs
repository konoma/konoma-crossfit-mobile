using System;
using Konoma.CrossFit;

namespace Sample.Core
{
    public interface IMainScreen : ISceneScreen
    {
        event EventHandler? Created;

        event EventHandler? GarbageCollectorPressed;

        event EventHandler? OpenModalPressed;

        void SetLabels(MainSceneLabels labels);

        void NavigateToModal(LeafScene scene);
    }
}
