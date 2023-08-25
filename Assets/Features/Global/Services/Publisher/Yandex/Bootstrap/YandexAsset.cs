using Common.Architecture.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Services.Publisher.Abstract.Advertisment;
using Global.Services.Publisher.Abstract.Bootstrap;
using Global.Services.Publisher.Abstract.DataStorages;
using Global.Services.Publisher.Abstract.Languages;
using Global.Services.Publisher.Abstract.Leaderboards;
using Global.Services.Publisher.Abstract.Purchases;
using Global.Services.Publisher.Abstract.Reviews;
using Global.Services.Publisher.Abstract.Saves;
using Global.Services.Publisher.Yandex.Advertisement;
using Global.Services.Publisher.Yandex.Common;
using Global.Services.Publisher.Yandex.DataStorages;
using Global.Services.Publisher.Yandex.Debugs;
using Global.Services.Publisher.Yandex.Debugs.Ads;
using Global.Services.Publisher.Yandex.Debugs.Purchases;
using Global.Services.Publisher.Yandex.Debugs.Reviews;
using Global.Services.Publisher.Yandex.Languages;
using Global.Services.Publisher.Yandex.Leaderboard;
using Global.Services.Publisher.Yandex.Purchases;
using Global.Services.Publisher.Yandex.Review;
using Global.Services.Setup.Service;
using Global.Services.Setup.Service.Scenes;
using Menu.Achievements.Global;
using Menu.Collections.Global;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.Publisher.Yandex.Bootstrap
{
    [InlineEditor]
    [CreateAssetMenu(fileName = YandexRoutes.ServiceName, menuName = YandexRoutes.ServicePath)]
    public class YandexAsset : PublisherSdkAsset
    {
        [SerializeField] [Scene] private string _debugScene;
        [SerializeField] private YandexCallbacks _callbacksPrefab;

        public override async UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks)
        {
            var yandexCallbacks = Instantiate(_callbacksPrefab, Vector3.zero, Quaternion.identity);
            yandexCallbacks.name = "YandexCallbacks";

            builder.RegisterComponent(yandexCallbacks);

            RegisterModules(builder);

            if (Application.isEditor == true)
                await RegisterEditorApis(builder, sceneLoader, yandexCallbacks);
            else
                RegisterBuildApis(builder);
        }

        private void RegisterModules(IDependencyRegister builder)
        {
            builder.Register<Ads>()
                .As<IAds>();

            var saves = GetSaves();

            builder.Register<DataStorage>()
                .As<IDataStorage>()
                .WithParameter(saves)
                .AsCallbackListener();

            builder.Register<LanguageProvider>()
                .As<ILanguageProvider>();

            builder.Register<LeaderboardsProvider>()
                .As<ILeaderboardsProvider>();

            builder.Register<Reviews>()
                .As<IReviews>();

            builder.Register<PurchaseProcessor>()
                .As<IPurchaseProcessor>();
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
                new LevelsSave(),
                new SoundSave(),
                new AchievementsSave(),
                new CollectionsSave()
            };
        }
    }
}