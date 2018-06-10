using UnityEngine;
using GreenApple.Poke.Core.Services;
using System;

namespace FireBullet.QBert.Services
{
    /// <summary>
    /// The Input service is responsible for detecting
    /// user input on the phone.
    /// </summary>
    public class MobileInputService : MonoBehaviour, IInputService
    {
        #region Public Variables
        public event Action OnUserTappedScreen;
        #endregion

        #region Main Methods
        private void Start() => RegisterService();

        public void RegisterService()
        {
            ServiceLocator.Register<IInputService>(this);
        }

        void Update()
        {
            CheckForTap();
        }
        #endregion

        #region Utility Methods
		private void CheckForTap()
		{
            #if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0)) OnUserTappedScreen?.Invoke();
            return;
            #endif

            Touch touchResult = Input.GetTouch(0);
			if (touchResult.phase == TouchPhase.Began)
				OnUserTappedScreen?.Invoke();
		}
        #endregion
    }
}
