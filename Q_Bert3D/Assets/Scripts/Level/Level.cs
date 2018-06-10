using UnityEngine;

namespace FireBullet.QBert.Levels
{
    /// <summary>
    /// The Level scriptable asset will 
    /// contain the information about each 
    /// level.
    /// </summary>
    [CreateAssetMenu(fileName = "NewLevel", menuName = "Levels/Level")]
    public class Level : ScriptableObject
    {
        public int NumberOfRows;
    }
}
