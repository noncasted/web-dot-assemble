using Global.Services.System.MessageBrokers.Runtime;

namespace GamePlay.Level.Services.Score.Runtime
{
    public class Score : IScore
    {
        private int _enemy;
        private int _player;

        public void SetEnemyScore(int score)
        {
            _enemy = score;
        }

        public void AddPlayerScore(int add)
        {
            _player += add;
            
            Msg.Publish(new ScoreUpdatedEvent(_player, _enemy));
        }
    }
}