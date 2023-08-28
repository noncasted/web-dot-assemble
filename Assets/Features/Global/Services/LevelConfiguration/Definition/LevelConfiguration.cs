﻿using Global.LevelConfiguration.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.LevelConfiguration.Definition
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelConfigurationRoutes.ConfigName,
        menuName = LevelConfigurationRoutes.ConfigPath)]
    public class LevelConfiguration : ScriptableObject, ILevelConfiguration
    {
        [SerializeField] [Min(0)] private int _targetScore;

        public int TargetScore => _targetScore;
    }
}