using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace FireBullet.QBert.General
{
    /// <summary>
    /// This component will invoke an invent in 
    /// a specified number of seconds after beginning
    /// to time.
    /// </summary>
    public class InvokeInSeconds : MonoBehaviour
    {
        #region Private Variables
        [SerializeField]
        private UnityEvent m_onTimingFinished;

        [SerializeField]
        private float m_timeCount;

        private bool m_isTiming = false;
        #endregion

        #region Main Methods
        public void BeginTiming()
        {
            if (m_isTiming) return;
            StartCoroutine(_BeginTiming());
        }
        #endregion

        #region Utility Methods
        private IEnumerator _BeginTiming()
        {
            m_isTiming = true;
            yield return new WaitForSeconds(m_timeCount);
            m_isTiming = false;
            m_onTimingFinished?.Invoke();
        }
        #endregion
    }
}
