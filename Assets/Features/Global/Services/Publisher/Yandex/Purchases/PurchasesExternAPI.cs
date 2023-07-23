using System.Runtime.InteropServices;

namespace Global.Services.Publisher.Yandex.Purchases
{
    public class PurchasesExternAPI : IPurchasesAPI
    {
        [DllImport("__Internal")]
        private static extern void Purchase(string id);

        public void Purchase_Internal(string id)
        {
            Purchase(id);
        }
    }
}