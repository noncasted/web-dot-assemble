namespace Menu.Main.UI.Runtime
{
    public interface IMenuView
    {
        void Open();
        void Close();
        void OnLoading();
        void CancelLoading();
    }
}