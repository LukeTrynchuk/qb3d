using UnityEngine;

namespace FireBullet.QBert.Levels
{
    /// <summary>
    /// Game Level data is a container for all the 
    /// world containers. The game level data is 
    /// the object that will be serialized and
    /// put on the server.
    /// </summary>
    [CreateAssetMenu(fileName = "NewGameLevelData", menuName = "Levels/GameLevelDataContainer")]
    public class GameLevelData : ScriptableObject 
    {
        public WorldContainer[] Worlds;
    }
}
