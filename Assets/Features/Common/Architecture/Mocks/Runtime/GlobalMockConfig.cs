using Global.GameLoops.Runtime;
using Global.Options.Runtime;
using Global.Setup.Abstract;
using Global.Setup.Scope;
using NaughtyAttributes;
using UnityEngine;

namespace Common.Architecture.Mocks.Runtime
{
    [CreateAssetMenu(fileName = "GlobalMockConfig", menuName = "Common/GlobalMockConfig")]
    public class GlobalMockConfig : ScriptableObject
    {
        [SerializeField] private GlobalScope _scope;
        [SerializeField] private Options _options;
        [SerializeField] private GameLoopFactory _gameLoop;
        [SerializeField] private GlobalServicesConfig _services;
        
        [SerializeField] [Scene] private string _servicesScene;

        public GlobalScope Scope => _scope;
        public IOptions Options => _options;
        public GameLoopFactory GameLoop => _gameLoop;
        public GlobalServicesConfig Services => _services;
        public string ServicesScene => _servicesScene;
    }
}