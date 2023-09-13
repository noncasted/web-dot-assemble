using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using GamePlay.Level.Services.Score.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Level.Services.Score.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ScoreRoutes.ServiceName,
        menuName = ScoreRoutes.ServicePath)]
    public class ScoreFactory : ScriptableObject, ILocalServiceFactory
    {
        public void Create(IDependencyRegister builder, ILocalUtils utils)
        {
            builder.Register<Score>()
                .As<IScore>();
        }
    }
}