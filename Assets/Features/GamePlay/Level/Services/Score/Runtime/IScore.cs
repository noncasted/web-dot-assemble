namespace GamePlay.Level.Services.Score.Runtime
{
    public interface IScore
    {
        void SetEnemyScore(int score);
        void AddPlayerScore(int add);
    }
}