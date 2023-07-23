using Global.Services.Publisher.Yandex.Debugs.Ads;
using Global.Services.Publisher.Yandex.Debugs.Purchases;
using Global.Services.Publisher.Yandex.Debugs.Reviews;
using UnityEngine;

namespace Global.Services.Publisher.Yandex.Debugs
{
    [DisallowMultipleComponent]
    public class YandexDebugCanvas : MonoBehaviour
    {
        [SerializeField] private AdsDebug _ads;
        [SerializeField] private PurchaseDebug _purchases;
        [SerializeField] private ReviewsDebug _reviews;

        public AdsDebug Ads => _ads;
        public PurchaseDebug Purchase => _purchases;
        public ReviewsDebug Reviews => _reviews;
    }
}