using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.Architecture.Mocks.Runtime
{
    [Serializable]
    public class GlobalMock
    {
        [SerializeField] private GlobalMockConfig _config;

        public async UniTask<MockBootstrapResult> BootstrapGlobal()
        {
            return null;
        }
    }
}