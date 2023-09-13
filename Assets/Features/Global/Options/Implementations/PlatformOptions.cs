using Global.Options.Runtime;
using Global.Publisher.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Options.Implementations
{
    [InlineEditor]
    public class PlatformOptions : OptionsEntry
    {
        [SerializeField] private TargetPlatform _platform;

        public TargetPlatform Platform => _platform;
        
        public bool IsEditor
        {
            get
            {
#if UNITY_EDITOR
                return true;
#endif
                return false;
            }
        }
    }
}