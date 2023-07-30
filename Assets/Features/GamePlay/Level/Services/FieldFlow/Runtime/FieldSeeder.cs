using GamePlay.Level.Dots.Definitions;
using GamePlay.Level.Dots.Factory;
using GamePlay.Level.Dots.Runtime.LifeFlow;
using GamePlay.Level.Fields.Runtime;

namespace GamePlay.Level.Services.FieldFlow.Runtime
{
    public class FieldSeeder : IFieldSeeder
    {
        public FieldSeeder(IDotFactory dotFactory, IField field, IDotDefinitionsStorage definitions, IDotLifeFlowConfig config)
        {
            _dotFactory = dotFactory;
            _field = field;
            _definitions = definitions;
            _config = config;
        }

        private readonly IDotFactory _dotFactory;
        private readonly IField _field;
        private readonly IDotDefinitionsStorage _definitions;
        private readonly IDotLifeFlowConfig _config;

        public void SeedStartup(int amount)
        {
            for (var i = 0; i < amount; i++)
                SpawnDotAtRandomPosition();
        }

        public void SeedInGame()
        {
            var cell = _field.GetRandomAvailableCell();
            var definition = _definitions.GetRandom();
            _dotFactory.Create(definition, cell, _config, false);
        }

        private void SpawnDotAtRandomPosition()
        {
            var cell = _field.GetRandomAvailableCell();
            var definition = _definitions.GetRandom();
            _dotFactory.Create(definition, cell, _config, true);
        }
    }
}