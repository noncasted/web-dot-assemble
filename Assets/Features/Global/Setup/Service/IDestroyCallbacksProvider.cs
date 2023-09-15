using System.Collections.Generic;

namespace Global.Setup.Service
{
    public interface IDestroyCallbacksProvider
    {
        IReadOnlyList<IAsyncCallbackHandler> DestroyListeners { get; }
    }
}