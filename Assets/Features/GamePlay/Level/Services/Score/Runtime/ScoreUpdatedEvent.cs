namespace GamePlay.Level.Services.Score.Runtime
{
    public readonly struct ScoreUpdatedEvent
    {
        public ScoreUpdatedEvent(int playerScore, int enemyScore)
        {
            PlayerScore = playerScore;
            EnemyScore = enemyScore;
        }

        public readonly int PlayerScore;
        public readonly int EnemyScore;
    }
}