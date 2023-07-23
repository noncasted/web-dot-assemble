using MPUIKIT;
using UnityEngine;

namespace Menu.Main.UI.Runtime
{
    [DisallowMultipleComponent]
    public class LoadingBar : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        [SerializeField] private MPImage _image;

        private float _progress;

        private void Update()
        {
            var delta = Time.deltaTime * _speed;
            _progress += delta;

            if (_progress >= 1f)
                _progress = 0f;

            _image.fillAmount = _progress;
        }
    }
}