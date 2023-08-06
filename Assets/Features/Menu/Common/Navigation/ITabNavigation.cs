using Menu.StateMachine.Runtime;

namespace Features.Menu.Common.Navigation
{
    public interface ITabNavigation
    {
        void Construct(IStateMachine stateMachine);
        void Enable();
        void Disable();
    }
}