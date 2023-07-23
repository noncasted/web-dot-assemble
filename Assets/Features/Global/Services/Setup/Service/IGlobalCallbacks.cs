using Global.Services.Setup.Service.Callbacks;

namespace Global.Services.Setup.Service
{
    public interface IGlobalCallbacks
    {
        void Listen(object listener);
        void AddInternalCallbackLoop(IGlobalInternalCallbackLoop callbackLoop);
    }
}