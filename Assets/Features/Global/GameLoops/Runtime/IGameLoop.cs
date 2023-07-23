namespace Global.GameLoops.Runtime
{
    public interface IGameLoop
    {
        void OnBootstrapped();
        void Start();
    }
}