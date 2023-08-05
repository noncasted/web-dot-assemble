﻿using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
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
        public void Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            IEventLoopsRegistry loopsRegistry)
        {
            builder.Register<Score>()
                .As<IScore>();
        }
    }
}