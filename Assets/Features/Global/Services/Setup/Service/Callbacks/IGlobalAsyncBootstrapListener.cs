using Cysharp.Threading.Tasks;

namespace Global.Services.Setup.Service.Callbacks
{
    public interface IGlobalAsyncBootstrapListener
    {
        UniTask OnBootstrapAsync();
    }
}