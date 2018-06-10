using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using System.IO;

namespace FireBullet.QBert.Utility
{
    /// <summary>
    /// The Application Utility class is responsible
    /// for containing a series of helper methods
    /// for other objects to gain information about 
    /// the application.
    /// </summary>
    public class ApplicationUtility : IPreprocessBuildWithReport
    {
        public int callbackOrder => 2;
        #region Main Methods
        private static string GetBuildVersion() => Application.version;
        private static string GetBuildNumber() => UnityEditor.PlayerSettings.iOS.buildNumber;

        public void OnPreprocessBuild(BuildReport report)
        {
            string version = $"BUILD {GetBuildVersion()}.{GetBuildNumber()} ";
            File.WriteAllText(Application.dataPath + "/Resources/Version/version.txt", version);
        }
        #endregion
    }
}
