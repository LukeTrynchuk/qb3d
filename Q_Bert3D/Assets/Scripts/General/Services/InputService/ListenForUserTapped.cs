using UnityEngine;
using UnityEngine.Events;
using FireBullet.QBert.Services;
using GreenApple.Poke.Core.Services;

namespace FireBullet.QBert.General
{
    /// <summary>
    /// The Listen for user tapped component will
    /// subscribe to the user tapped event from the
    /// Input service and invoke a unity event when
    /// the user does so.
    /// </summary>
    public class ListenForUserTapped : MonoBehaviour
    {
        #region Private Variables
        [SerializeField]
		private UnityEvent m_onUserTapped;

        private ServiceReference<IInputService> m_inputService
                        = new ServiceReference<IInputService>();
        #endregion

        #region Main Methods
        private void OnEnable()
        {
            m_inputService.AddRegistrationHandle(HandleInputServiceRegistered);
        }

		private void OnDisable()
		{
			if(m_inputService.isRegistered())
            {
                m_inputService.Reference.OnUserTappedScreen -= UserTapped;
            }
		}

		private void UserTapped() => m_onUserTapped?.Invoke();
        #endregion

        #region Utility Methods
        void HandleInputServiceRegistered()
        {
            m_inputService.Reference.OnUserTappedScreen -= UserTapped;
            m_inputService.Reference.OnUserTappedScreen += UserTapped;
        }
        #endregion
    }
}
