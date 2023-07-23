namespace Common.UI.UniversalPlates.Runtime.Switches
{
    public interface IColorSwitchTarget
    {
        void Init();
        void ToActive(float progress);
        void ToBase(float progress);
    }
}