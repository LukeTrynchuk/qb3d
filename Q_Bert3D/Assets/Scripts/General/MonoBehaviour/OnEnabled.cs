using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FireBullet.QBert.General
{
    /// <summary>
    /// The On Enable will invoke an event
    /// when the OnEnable method of the 
    /// monobehaviour is called
    /// </summary>
    public class OnEnabled : MonoBehaviour
    {
        #region Private Variables
        [SerializeField]
        private UnityEvent m_onEnabled;
        #endregion

        #region Main Methods
        private void OnEnable() => m_onEnabled?.Invoke();
		#endregion
	}
}
