﻿using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Global.Scenes.Operations.Abstract;
using Global.Scenes.Operations.Data;

namespace Common.Architecture.Local.ComposedSceneConfig
{
    public class ComposedSceneLoader : ISceneLoader
    {
        public ComposedSceneLoader(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private readonly List<ISceneLoadResult> _results = new();
        private readonly ISceneLoader _sceneLoader;

        public IReadOnlyList<ISceneLoadResult> Results => _results;

        public async UniTask<ISceneLoadResult> Load(ISceneAsset sceneAsset)
        {
            var result = await _sceneLoader.Load(sceneAsset);

            _results.Add(result);

            return result;
        }

        public async UniTask<ISceneLoadTypedResult<T>> LoadTyped<T>(ISceneAsset sceneAsset)
        {
            var result = await _sceneLoader.LoadTyped<T>(sceneAsset);

            _results.Add(result);

            return result;
        }
    }
}