using UnityEngine;
using UnityEngine.Events;

namespace FireBullet.QBert.General
{
    /// <summary>
    /// The On Start Component can be attached to a game
    /// object and it will invoke a unity event on start.
    /// </summary>
    public class OnStart : MonoBehaviour
    {
        #region Private Variabels
        [SerializeField]
        private UnityEvent m_onStart;
        #endregion

        #region Main Methods
        private void Start() => m_onStart?.Invoke();
		#endregion
	}
}
