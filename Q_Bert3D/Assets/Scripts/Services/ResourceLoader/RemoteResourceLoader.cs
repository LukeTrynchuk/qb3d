using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using GreenApple.Poke.Core.Services;

namespace FireBullet.QBert.Services
{
    /// <summary>
    /// The Resource loader is responsible for loading 
    /// remote  resources.
    /// </summary>
    public class RemoteResourceLoader : MonoBehaviour, IResourceLoader
    {
        #region Public Variables
        public event Action OnResourcesLoaded;
        #endregion

        #region Private Variables
        private float m_progress = 0f;
        private ResourceLoaderState m_state = ResourceLoaderState.IDLE;
        #endregion

        #region Main Methods
        public void LoadResources() => StartCoroutine(Load());

        public float GetProgress() => m_progress;

        public ResourceLoaderState GetState() => m_state;

        void Start() => RegisterService();
        #endregion

        #region Utility Methods
        IEnumerator Load()
        {
            m_state = ResourceLoaderState.LOADING;
            float loadingTime = 0f;

            do
            {
                loadingTime += Time.deltaTime;
                m_progress = Mathf.Pow(loadingTime / 2f, loadingTime / 2f);
                m_progress = Mathf.Clamp01(m_progress);
                yield return null;
            } while (loadingTime < 2f);

            m_state = ResourceLoaderState.IDLE;
            OnResourcesLoaded?.Invoke();
        }

        public void RegisterService()
        {
            ServiceLocator.Register<IResourceLoader>(this);
        }
        #endregion
    }
}
