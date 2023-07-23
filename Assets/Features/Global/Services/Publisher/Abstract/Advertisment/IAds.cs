using Cysharp.Threading.Tasks;

namespace Global.Services.Publisher.Abstract.Advertisment
{
    public interface IAds
    {
        void ShowInterstitial();
        UniTask<RewardAdResult> ShowRewarded();
    }
}