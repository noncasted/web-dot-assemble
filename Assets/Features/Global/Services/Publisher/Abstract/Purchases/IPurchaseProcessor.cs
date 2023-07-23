using Cysharp.Threading.Tasks;

namespace Global.Services.Publisher.Abstract.Purchases
{
    public interface IPurchaseProcessor
    {
        UniTask<PurchaseResult> Purchase(IPurchaseIdProvider idProvider);
    }
}