using System;
using Konoma.CrossFit;

namespace Sample.Core
{
    public interface ILeafScreen : ISceneScreen
    {
        event EventHandler? Created;

        event EventHandler? BackPressed;

        void SetContent(string content);

        void NavigateBack();
    }
}
