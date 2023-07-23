using System.Collections.Generic;
using Global.Services.Setup.Service.Callbacks;

namespace Global.Services.Setup.Service
{
    public interface IDestroyCallbacksProvider
    {
        IReadOnlyList<IGlobalDestroyListener> DestroyListeners { get; }
    }
}