using Common.Architecture.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Audio.Player.Runtime;
using Global.Localizations.Runtime;
using Global.Options.Implementations;
using Global.Publisher.Abstract.Advertisment;
using Global.Publisher.Abstract.Bootstrap;
using Global.Publisher.Abstract.DataStorages;
using Global.Publisher.Abstract.Languages;
using Global.Publisher.Abstract.Leaderboards;
using Global.Publisher.Abstract.Purchases;
using Global.Publisher.Abstract.Reviews;
using Global.Publisher.Yandex.Advertisement;
using Global.Publisher.Yandex.Common;
using Global.Publisher.Yandex.DataStorages;
using Global.Publisher.Yandex.Debugs;
using Global.Publisher.Yandex.Debugs.Ads;
using Global.Publisher.Yandex.Debugs.Purchases;
using Global.Publisher.Yandex.Debugs.Reviews;
using Global.Publisher.Yandex.Languages;
using Global.Publisher.Yandex.Leaderboard;
using Global.Publisher.Yandex.Purchases;
using Global.Publisher.Yandex.Review;
using Global.Setup.Service;
using Global.Setup.Service.Scenes;
using Menu.Achievements.Global;
using Menu.Calendar.Global;
using Menu.Collections.Global;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Publisher.Yandex.Bootstrap
{
    [InlineEditor]
    [CreateAssetMenu(fileName = YandexRoutes.ServiceName, menuName = YandexRoutes.ServicePath)]
    public class YandexFactory : PublisherSdkFactory
    {
        [SerializeField] [Scene] private string _debugScene;
        [SerializeField] private YandexCallbacks _callbacksPrefab;
        [SerializeField] private ShopProductsRegistry _productsRegistry;
        [SerializeField] private ProductLink _adsDisableProduct;

        public override async UniTask Create(IDependencyRegister builder, IGlobalSceneLoader sceneLoader, IGlobalUtils utils)
        {
            var yandexCallbacks = Instantiate(_callbacksPrefab, Vector3.zero, Quaternion.identity);
            yandexCallbacks.name = "YandexCallbacks";

            builder.RegisterComponent(yandexCallbacks);

            RegisterModules(builder);

            var options = utils.Options.GetOptions<PlatformOptions>();
            
            if (options.IsEditor == true)
                await RegisterEditorApis(builder, sceneLoader, yandexCallbacks);
            else
                RegisterBuildApis(builder);
        }

        private void RegisterModules(IDependencyRegister builder)
        {
            builder.Register<Ads>()
                .WithParameter<IProductLink>(_adsDisableProduct)
                .As<IAds>();

            var saves = GetSaves();

            builder.Register<DataStorage>()
                .As<IDataStorage>()
                .WithParameter(saves)
                .AsCallbackListener();

            builder.Register<SystemLanguageProvider>()
                .As<ISystemLanguageProvider>();

            builder.Register<LeaderboardsProvider>()
                .As<ILeaderboardsProvider>();

            builder.Register<Reviews>()
                .As<IReviews>();

            builder.Register<Payments>()
                .WithParameter(_productsRegistry)
                .As<IPayments>();
        }

        private async UniTask RegisterEditorApis(
            IDependencyRegister builder,
            IGlobalSceneLoader sceneLoader,
            YandexCallbacks callbacks)
        {
            var sceneData = new InternalScene<YandexDebugCanvas>(_debugScene);
            var loadResult = await sceneLoader.LoadAsync(sceneData);

            var canvas = loadResult.Searched;

            canvas.Ads.Construct(callbacks);
            canvas.Reviews.Construct(callbacks);
            canvas.Purchase.Construct(callbacks);

            builder.Register<AdsDebugAPI>()
                .As<IAdsAPI>()
                .WithParameter<IAdsDebug>(canvas.Ads);

            builder.Register<StorageDebugAPI>()
                .As<IStorageAPI>();

            builder.Register<LanguageDebugAPI>()
                .As<ILanguageAPI>();

            builder.Register<LeaderboardsDebugAPI>()
                .As<ILeaderboardsAPI>();

            builder.Register<PurchasesDebugAPI>()
                .As<IPurchasesAPI>()
                .WithParameter(_productsRegistry)
                .WithParameter<IPurchaseDebug>(canvas.Purchase);

            builder.Register<ReviewsDebugAPI>()
                .As<IReviewsAPI>()
                .WithParameter<IReviewsDebug>(canvas.Reviews);
        }

        private void RegisterBuildApis(IDependencyRegister builder)
        {
            builder.Register<AdsExternAPI>()
                .As<IAdsAPI>();

            builder.Register<StorageExternAPI>()
                .As<IStorageAPI>();

            builder.Register<LanguageExternAPI>()
                .As<ILanguageAPI>();

            builder.Register<LeaderboardsExternAPI>()
                .As<ILeaderboardsAPI>();

            builder.Register<PurchasesExternAPI>()
                .As<IPurchasesAPI>();

            builder.Register<ReviewsExternAPI>()
                .As<IReviewsAPI>();
        }

        private IStorageEntry[] GetSaves()
        {
            return new IStorageEntry[]
            {
                new SoundSave(),
                new AchievementsSave(),
                new CollectionsSave(),
                new LanguageSave(),
                new PurchasesSave(),
                new CalendarSave()
            };
        }
    }
}