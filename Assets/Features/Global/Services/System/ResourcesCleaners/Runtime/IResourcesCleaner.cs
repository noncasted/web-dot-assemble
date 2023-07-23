using Cysharp.Threading.Tasks;

namespace Global.Services.System.ResourcesCleaners.Runtime
{
    public interface IResourcesCleaner
    {
        UniTask CleanUp();
    }
}