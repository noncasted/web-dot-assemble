using Cysharp.Threading.Tasks;

namespace Global.Services.Publisher.Abstract.Reviews
{
    public interface IReviews
    {
        UniTask Review();
    }
}