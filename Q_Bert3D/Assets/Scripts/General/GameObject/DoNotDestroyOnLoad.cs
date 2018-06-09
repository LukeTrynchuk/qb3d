using UnityEngine;

namespace FireBullet.QBert.General
{
    /// <summary>
    /// The Do Not Destoy On Load component can be attached
    /// to any game object to not be destroyed on load.
    /// </summary>
    public class DoNotDestroyOnLoad : MonoBehaviour
    {
        #region Main Methods
        private void Start() => DontDestroyOnLoad(gameObject);
		#endregion
	}
}
