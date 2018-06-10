using UnityEngine;
using UnityEngine.SceneManagement;

namespace FireBullet.QBert.Scenes
{
    /// <summary>
    /// The Load Scene By Name will load a scene
    /// given a scene name.
    /// </summary>
    public class LoadSceneByName : MonoBehaviour
    {
        #region Main Methods
        public void LoadScene(string sceneName)
        {
            if(!SceneExists(sceneName))
            {
                HandleSceneDoesntExist(sceneName);
                return;
            }

            Load(sceneName);
        }
        #endregion

        #region Utility Methods
        private bool SceneExists(string sceneName)
        {
            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(i);
                if (path.Contains($"/{sceneName}.unity")) return true;
            }

            return false;
        }

        private void HandleSceneDoesntExist(string sceneName)
        {
            Debug.LogError($"Scene with name {sceneName} does not exist in build settings.");
        }

        private void Load(string sceneName) => SceneManager.LoadScene(sceneName);
        #endregion
    }
}
