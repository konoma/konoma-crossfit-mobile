using System;
using Konoma.CrossFit;

namespace Sample.Core
{
    public interface IMainScreen : ISceneScreen
    {
        event EventHandler? Created;
    }
}
