﻿using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace Global.Services.Scenes.ScenesFlow.Logs
{
    [Serializable]
    public class ScenesFlowLogs : ReadOnlyDictionary<ScenesFlowLogType, bool>
    {
    }
}