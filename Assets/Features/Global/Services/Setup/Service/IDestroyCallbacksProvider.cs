using System.Collections.Generic;
using Global.Bootstrappers;
using Global.Services.Setup.Service.Callbacks;

namespace Global.Services.Setup.Service
{
    public interface IDestroyCallbacksProvider
    {
        IReadOnlyList<IAsyncCallbackHandler> DestroyListeners { get; }
    }
}