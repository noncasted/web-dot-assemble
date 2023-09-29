using Global.GameLoops.Runtime;
using Internal.Services.Options.Runtime;
using NaughtyAttributes;
using UnityEngine;

namespace Common.Architecture.Mocks.Runtime
{
    [CreateAssetMenu(fileName = "GlobalMockConfig", menuName = "Common/GlobalMockConfig")]
    public class GlobalMockConfig : ScriptableObject
    {
        [SerializeField] private Options _options;
        [SerializeField] private GameLoopFactory _gameLoop;
        
        [SerializeField] [Scene] private string _servicesScene;

        public IOptions Options => _options;
        public GameLoopFactory GameLoop => _gameLoop;
        public string ServicesScene => _servicesScene;
    }
}