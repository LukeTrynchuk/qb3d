using UnityEngine;

namespace FireBullet.QBert.Utility
{
    /// <summary>
    /// The Application Utility class is responsible
    /// for containing a series of helper methods
    /// for other objects to gain information about 
    /// the application.
    /// </summary>
    public class ApplicationUtility
    {
        #region Main Methods
        public static string GetBuildVersion() => Application.version;
        public static string GetBuildNumber() => UnityEditor.PlayerSettings.iOS.buildNumber;
        #endregion
    }
}
