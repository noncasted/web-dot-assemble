using Global.Services.Publisher.Abstract.DataStorages;

namespace Global.Services.Publisher.Abstract.Saves
{
    public static class SavesExtensions
    {
        public static LevelsSave GetLevels(this IDataStorage storage)
        {
            return storage.GetEntry<LevelsSave>(SavesPaths.Levels);
        }

        public static SoundSave GetSound(this IDataStorage storage)
        {
            return storage.GetEntry<SoundSave>(SavesPaths.Sounds);
        }
    }
}