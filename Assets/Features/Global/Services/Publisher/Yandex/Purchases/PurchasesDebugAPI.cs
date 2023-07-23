using Global.Services.Publisher.Yandex.Debugs.Purchases;

namespace Global.Services.Publisher.Yandex.Purchases
{
    public class PurchasesDebugAPI : IPurchasesAPI
    {
        public PurchasesDebugAPI(IPurchaseDebug debug)
        {
            _debug = debug;
        }

        private readonly IPurchaseDebug _debug;

        public void Purchase_Internal(string id)
        {
            _debug.Purchase(id);
        }
    }
}