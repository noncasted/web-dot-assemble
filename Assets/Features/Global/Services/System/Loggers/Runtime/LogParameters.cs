﻿using System;
using System.Collections.Generic;
using Common.Serialization.NestedScriptableObjects.Attributes;
using Global.System.Loggers.Runtime.Headers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.Loggers.Runtime
{
    [Serializable]
    public class LogParameters
    {
        [SerializeField] private bool _isMessageColored;

        [ShowIf("_isMessageColored")] [SerializeField] [ColorPalette]
        private Color _color;

        [SerializeField] [NestedScriptableObjectList]
        private List<LoggerHeader> _headers = new();

        public bool IsMessageColored => _isMessageColored;
        public string Color => ColorUtility.ToHtmlStringRGB(_color);

        public IReadOnlyList<LoggerHeader> Headers => _headers;
    }
}