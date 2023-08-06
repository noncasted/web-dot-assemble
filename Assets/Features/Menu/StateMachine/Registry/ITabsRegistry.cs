using Menu.StateMachine.Definitions;

namespace Menu.StateMachine.Registry
{
    public interface ITabsRegistry
    {
        void Register(ITabDefinition definition, ITab tab);
        ITab GetTab(ITabDefinition definition);
    }
}