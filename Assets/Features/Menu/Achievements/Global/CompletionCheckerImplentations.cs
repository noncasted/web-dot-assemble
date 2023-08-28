using System;
using Global.System.MessageBrokers.Runtime;
using Menu.Achievements.Definitions;

namespace Menu.Achievements.Global
{
    public abstract class AchievementCompletionChecker<T> : IAchievementCompletionChecker
    {
        public AchievementCompletionChecker(IAchievementProgress progress)
        {
            _progress = progress;
        }

        private readonly IAchievementProgress _progress;

        private IDisposable _listener;

        public event Action Completed;

        public IAchievementProgress Progress => _progress;

        public void Enable()
        {
            _listener = Msg.Listen<T>(OnMessageReceived);
        }

        public void Disable()
        {
            _listener?.Dispose();
        }

        private void OnMessageReceived(T payload)
        {
            if (Check(payload) == false)
                return;

            Completed?.Invoke();
        }

        protected abstract bool Check(T payload);
    }

    public readonly struct TestPayload
    {
    }

    public class AchievementTypeHandlerProgress<T> : AchievementCompletionChecker<T>
    {
        public AchievementTypeHandlerProgress(IAchievementProgress progress) : base(progress)
        {
        }

        protected override bool Check(T payload)
        {
            Progress.Update(Progress.Value + 1);

            if (Progress.Value >= Progress.Target)
                return true;

            return false;
        }
    }
}