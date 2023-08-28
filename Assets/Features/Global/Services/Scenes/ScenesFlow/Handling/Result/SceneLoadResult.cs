﻿using UnityEngine.SceneManagement;

namespace Global.Scenes.ScenesFlow.Handling.Result
{
    public abstract class SceneLoadResult
    {
        public SceneLoadResult(Scene scene)
        {
            Scene = scene;
        }

        public readonly Scene Scene;
    }
}