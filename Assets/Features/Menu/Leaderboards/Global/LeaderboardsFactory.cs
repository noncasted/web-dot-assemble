﻿using Common.Architecture.DiContainer.Abstract;
using Global.Services.Setup.Service;
using Menu.Leaderboards.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Leaderboards.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LeaderboardsRoutes.ServiceName,
        menuName = LeaderboardsRoutes.ServicePath)]
    public class LeaderboardsFactory : ScriptableObject, IGlobalServiceFactory
    {
        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<Leaderboards>()
                .As<ILeaderboards>();
        }
    }
}