namespace GamePlay.Level.Services.FieldFlow.Runtime
{
    public interface IFieldSeeder
    {
        void SeedStartup(int amount);
        void SeedInGame();
    }
}