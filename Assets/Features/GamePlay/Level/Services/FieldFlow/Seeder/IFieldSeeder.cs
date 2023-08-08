using GamePlay.Level.Dots.Definitions;

namespace GamePlay.Level.Services.FieldFlow.Seeder
{
    public interface IFieldSeeder
    {
        void SeedStartup(int amount);
        void SeedInGame();
        void SeedReplacement(IDotDefinition definition);
    }
}