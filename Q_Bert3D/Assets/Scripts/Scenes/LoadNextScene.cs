using UnityEngine;
using UnityEngine.SceneManagement;

namespace FireBullet.QBert.Scenes
{
    /// <summary>
    /// The Load Next Scene component will load the next
	/// scene when asked to.
    /// </summary>
    public class LoadNextScene : MonoBehaviour
    {
        #region Main Methods
        public void AdvanceScene()
        {
            int buildIndex = GetNewBuildIndex();

            if (buildIndex >= SceneManager.sceneCountInBuildSettings) return;
            SceneManager.LoadScene(buildIndex);
        }

        private int GetNewBuildIndex()
        {
            Scene scene = SceneManager.GetActiveScene();
            int buildIndex = scene.buildIndex;
            buildIndex++;
            return buildIndex;
        }
        #endregion
    }
}
