namespace Common.UI.UniversalPlates.Runtime
{
    public interface IPlateFeature
    {
        bool IsUpdatable { get; }

        void Init();
        void Disable();
        void OnLocked();
        void Update();
    }
}