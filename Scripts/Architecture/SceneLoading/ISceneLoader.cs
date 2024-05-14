using System;

namespace Project.Scripts.Architecture.SceneLoading
{
    public interface ISceneLoader
    {
        public void Load(string sceneName, Action onLoaded = null);
    }
}