using GamePlay.Level.Dots.Definitions;
using Menu.Common.Navigation;
using UnityEngine;

namespace Menu.Main.UI
{
    public interface IMainView
    {
        IModeSelection ModeSelection { get; }
        ITabNavigation Navigation { get; }
        RectTransform Transform { get; }

        void Construct(IMainInterceptor interceptor, IDotDefinitionsStorage dotDefinitionsStorage);
    }
}