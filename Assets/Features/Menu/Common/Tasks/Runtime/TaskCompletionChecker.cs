using System;
using Menu.Common.Tasks.Abstract;

namespace Menu.Common.Tasks.Runtime
{
    public abstract class TaskCompletionChecker<T> : ITaskCompletionChecker
    {
        public TaskCompletionChecker(ITaskTriggerListenerFactory<T> triggerListenerFactory)
        {
            _triggerListenerFactory = triggerListenerFactory;
        }

        private readonly ITaskTriggerListenerFactory<T> _triggerListenerFactory;

        private IDisposable _listener;

        public event Action Completed;

        public void Construct()
        {
            _listener = _triggerListenerFactory.Create(OnTriggered);
        }

        public void Dispose()
        {
            _listener?.Dispose();
        }

        protected abstract void OnTriggered(T payload);
    }

    public class ProgressionTaskCompletionChecker : TaskCompletionChecker<IProgressionTask>
    {
        public ProgressionTaskCompletionChecker(
            ITaskProgress progress,
            ITaskTriggerListenerFactory<IProgressionTask> triggerListenerFactory) : base(triggerListenerFactory)
        {
            _progress = progress;
        }

        private readonly ITaskProgress _progress;

        protected override void OnTriggered(IProgressionTask payload)
        {
            _progress.OnProgress(payload.Value);
        }
    }

    public class ProgressionTaskTrigger<T> : ITaskTrigger<T>, IProgressionTask
    {
        public ProgressionTaskTrigger(int value)
        {
            _value = value;
        }

        private readonly int _value;

        public int Value => _value;
        
        public ITask CreateHandle()
        {
            return null;
        }
    }
}