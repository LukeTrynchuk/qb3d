using UnityEngine;
using GreenApple.Poke.Core.Services;

namespace FireBullet.QBert.Services
{
    /// <summary>
    /// The IResource Loader is a contract that all
    /// resource loaders must implement.
    /// 
    /// A resource loader should load resources from
    /// some source and organize them for use by other
    /// systems.
    /// </summary>
    public interface IResourceLoader : IService
    {
        event System.Action OnResourcesLoaded;

        void LoadResources();
        float GetProgress();
        ResourceLoaderState GetState();
    }

    public enum ResourceLoaderState
    {
        IDLE,
        LOADING
    }
}
