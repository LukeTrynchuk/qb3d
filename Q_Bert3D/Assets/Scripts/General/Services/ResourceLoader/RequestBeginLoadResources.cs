using UnityEngine;
using FireBullet.QBert.Services;
using GreenApple.Poke.Core.Services;

namespace FireBullet.QBert.General
{
    /// <summary>
    /// The Request Begin Load Resources component will
    /// request a load from the Resource Loader.
    /// </summary>
    public class RequestBeginLoadResources : MonoBehaviour
    {
        #region Private Variables
        private ServiceReference<IResourceLoader> m_resourceLoader 
                    = new ServiceReference<IResourceLoader>();
		#endregion

		#region Main Methods
		public void Load() => m_resourceLoader.Reference?.LoadResources();
		#endregion
	}
}
