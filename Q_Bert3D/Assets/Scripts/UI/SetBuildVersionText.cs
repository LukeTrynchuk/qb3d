using UnityEngine;
using UnityEngine.UI;
using System.IO;

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
        private void Start() 
        {
            string version = File.ReadAllText(Application.dataPath + "/Resources/Version/version.txt");
            m_text.text = version;
        }
		#endregion
	}
}
