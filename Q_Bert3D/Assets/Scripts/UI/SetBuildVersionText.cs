using UnityEngine;
using FireBullet.QBert.Utility;
using UnityEngine.UI;

namespace FireBullet.QBert.UI
{
    /// <summary>
    /// The Set build version text will set a 
    /// text object with the build version
    /// information.
    /// </summary>
    public class SetBuildVersionText : MonoBehaviour
    {
        #region Private Variables
        [SerializeField]
        private Text m_text;
        #endregion

        #region Main Methods
        private void Start() => m_text.text = $"BUILD {ApplicationUtility.GetBuildVersion()}.{ApplicationUtility.GetBuildNumber()} ";
		#endregion
	}
}
