using System;
using GamePlay.Loop.Modes;

namespace Menu.Main.UI
{
    public interface IModeSelection
    {
        event Action<GameMode> Selected;

        void SetMode(GameMode mode);
    }
}