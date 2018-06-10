using UnityEngine;
using UnityEngine.Events;

namespace FireBullet.QBert.UI
{
    /// <summary>
    /// The fade out controller contols the fade out / in 
    /// effect and invokes events when the fade in / out is
    /// complete.
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class FadeOutController : MonoBehaviour
    {
        #region Private Variables
        [SerializeField]
        private UnityEvent m_onFadeInComplete;

        [SerializeField]
        private UnityEvent m_onFadeOutComplete;

        private Animator m_animator;
		#endregion

		#region Main Methods
		private void Start() => m_animator = GetComponent<Animator>();

        public void OnFinishedFadeIn() => m_onFadeInComplete?.Invoke();

        public void OnFinishedFadeOut() => m_onFadeOutComplete?.Invoke();

        public void FadeOut() => m_animator.SetTrigger("Fade");
        #endregion
	}
}
