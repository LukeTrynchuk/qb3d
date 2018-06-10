using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace FireBullet.QBert.EditorTools
{
    /// <summary>
    /// The Build Number Incrementor increments the build 
    /// number of the application before the build begins.
    /// </summary>
    public class BuildNumberIncrementor : IPreprocessBuildWithReport
    {
        public int callbackOrder => 1;

        public void OnPreprocessBuild(BuildReport report)
        {
            string buildNumber = PlayerSettings.iOS.buildNumber;
            int build = int.Parse(buildNumber);
            build++;
            PlayerSettings.iOS.buildNumber = build.ToString();
        }
    }
}
