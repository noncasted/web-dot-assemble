using UnityEngine;

namespace Common.Architecture.Local.ComposedSceneConfig
{
    [CreateAssetMenu(fileName = "ComposedSceneConfig",
        menuName = "Local/Config/ComposedScene")]
    public class ComposedScenesConfig : ScriptableObject
    {
        [SerializeField] private string _servicesScene;

        public string ServicesScene => _servicesScene;
    }
}