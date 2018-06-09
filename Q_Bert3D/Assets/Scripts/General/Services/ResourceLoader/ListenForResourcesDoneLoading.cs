using UnityEngine;
using UnityEngine.Events;
using GreenApple.Poke.Core.Services;
using FireBullet.QBert.Services;

namespace FireBullet.QBert.General
{
    /// <summary>
    /// The Listen for resources done loading will
    /// subscribe to the resources done loading event
    /// from the resource loader service. 
    /// 
    /// When the event is detected this component will
    /// fire off an event of its own for other objects
    /// to subscribe to.
    /// </summary>
    public class ListenForResourcesDoneLoading : MonoBehaviour
    {
        #region Private Variables
        [SerializeField]
        private UnityEvent m_onResourcesDoneLoading;

        private ServiceReference<IResourceLoader> m_resourceLoader
                        = new ServiceReference<IResourceLoader>();
        #endregion

        #region Main Methods
        private void Start()
        {
            m_resourceLoader.AddRegistrationHandle(HandleResourceLoaderRegistered);
        }

		private void OnDisable()
		{
		    if(m_resourceLoader.isRegistered())
            {
                m_resourceLoader.Reference.OnResourcesLoaded -= ResourcesDoneLoading;
            }
		}

		private void ResourcesDoneLoading() => m_onResourcesDoneLoading?.Invoke();
        #endregion

        #region Utility Methods
        void HandleResourceLoaderRegistered()
        {
            m_resourceLoader.Reference.OnResourcesLoaded -= ResourcesDoneLoading;
            m_resourceLoader.Reference.OnResourcesLoaded += ResourcesDoneLoading;
        }
        #endregion
    }
}
