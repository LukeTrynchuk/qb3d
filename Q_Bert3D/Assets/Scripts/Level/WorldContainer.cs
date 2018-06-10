using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FireBullet.QBert.Levels
{
    /// <summary>
    /// The World Container contains a series of
    /// levels which make up a world / section.
    /// </summary>
    [CreateAssetMenu(fileName = "NewWorldContainer", menuName = "Levels/World")]
    public class WorldContainer : ScriptableObject
    {
        public Level[] Levels;
    }
}
