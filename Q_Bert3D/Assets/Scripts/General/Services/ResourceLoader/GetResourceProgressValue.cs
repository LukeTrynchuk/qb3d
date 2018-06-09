using UnityEngine;
using FireBullet.QBert.Services;
using GreenApple.Poke.Core.Services;

namespace FireBullet.QBert.General
{
    /// <summary>
    /// The Get Resource Progress Value will invoke an event 
    /// every update while the resource loader is loading 
    /// resources.
    /// 
    /// This component will inform other objects the state
    /// of the resource loader.
    /// </summary>
    public class GetResourceProgressValue : MonoBehaviour
    {
        #region Private Variables
        [SerializeField]
        private DynamicFloatEvent m_progressValueUpdated;

        private ServiceReference<IResourceLoader> m_resourceLoader 
                        = new ServiceReference<IResourceLoader>();
        #endregion

        #region Main Methods
        private void Start()
        {
            if (!m_resourceLoader.isRegistered()) return;
            if (m_resourceLoader.Reference.GetState() == ResourceLoaderState.IDLE) return;

            m_progressValueUpdated?.Invoke(m_resourceLoader.Reference.GetProgress());
        }
        #endregion
    }
}
