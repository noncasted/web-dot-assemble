﻿using Global.Scenes.ScenesFlow.Handling.Result;
using UnityEngine.SceneManagement;

namespace Global.Scenes.ScenesFlow.Handling.Data
{
    public class EmptySceneLoadData : SceneLoadData<EmptySceneLoadResult>
    {
        public EmptySceneLoadData(string name) : base(name)
        {
        }

        public override EmptySceneLoadResult CreateLoadResult(Scene scene)
        {
            return new EmptySceneLoadResult(scene);
        }
    }
}