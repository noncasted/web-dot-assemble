using Global.Services.Setup.Service.Callbacks;
using UnityEngine;

namespace Global.Services.Audio.Listener.Runtime
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioListenerSwitcher))]
    public class AudioListenerSwitcher : 
        MonoBehaviour,
        IAudioListenerSwitcher,
        IGlobalAwakeListener
    {
        private AudioListener _listener;
        
        public void OnAwake()
        {
            _listener = GetComponent<AudioListener>();
            Enable();    
        }
        
        public void Enable()
        {
            _listener.enabled = true;
        }

        public void Disable()
        {
            _listener.enabled = false;
        }
    }
}