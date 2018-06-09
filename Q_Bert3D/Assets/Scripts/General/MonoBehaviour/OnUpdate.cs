using UnityEngine;
using UnityEngine.Events;

namespace FireBullet.QBert.General
{
    /// <summary>
    /// The On Update component will invoke a 
    /// unity event on update.
    /// </summary>
    public class OnUpdate : MonoBehaviour
    {
        #region Private Variables
        [SerializeField]
        private UnityEvent m_onUpdate;
        #endregion

        #region Main Methods
        private void Update() => m_onUpdate?.Invoke();
		#endregion
	}
}
