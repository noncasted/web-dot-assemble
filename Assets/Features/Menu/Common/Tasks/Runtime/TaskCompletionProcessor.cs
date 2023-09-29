using Menu.Common.Tasks.Abstract;

namespace Menu.Common.Tasks.Runtime
{
    public abstract class TaskCompletionProcessor : ITaskCompletionProcessor
    {
        public TaskCompletionProcessor(ITaskCompletionChecker completionChecker)
        {
            _completionChecker = completionChecker;
        }

        private readonly ITaskCompletionChecker _completionChecker;
        
        public void Construct()
        {
            _completionChecker.Completed += OnCompleted;
        }

        public void Dispose()
        {
            _completionChecker.Completed -= OnCompleted;
        }

        protected abstract void OnCompleted();
    }
}