using Global.Services.Publisher.Yandex.Debugs.Reviews;

namespace Global.Services.Publisher.Yandex.Review
{
    public class ReviewsDebugAPI : IReviewsAPI
    {
        public ReviewsDebugAPI(IReviewsDebug debug)
        {
            _debug = debug;
        }

        private readonly IReviewsDebug _debug;

        public void Review_Internal()
        {
            _debug.Review();
        }
    }
}