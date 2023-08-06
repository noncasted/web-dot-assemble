using UnityEngine;

namespace Menu.StateMachine.Definitions
{
    public interface ITab
    {
        RectTransform Transform { get; }

        void Activate();
        void Deactivate();
    }
}