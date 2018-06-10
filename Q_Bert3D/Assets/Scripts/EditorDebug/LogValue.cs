using UnityEngine;

namespace FireBullet.QBert.EditorDebug
{
    /// <summary>
    /// The Log Value component is meant to be used to
    /// help debug within the Editor. 
    /// </summary>
    public class LogValue : MonoBehaviour
    {
        #region Main Methods

        public void LogObject(object value)
        {
        #if UNITY_EDITOR
            Debug.Log(value.ToString());
        #endif
        }

        public void LogFloat(float value)
        {
        #if UNITY_EDITOR
            Debug.Log(value.ToString());
        #endif
        }

        #endregion
    }
}
