using Menu.StateMachine.Definitions;

namespace Menu.StateMachine.Runtime
{
    public interface IMenuStateMachine
    {
        void Select(ITabDefinition tabDefinition, TabTransitionType transitionType);
    }
}