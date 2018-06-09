using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FireBullet.QBert.Services
{
    /// <summary>
    /// The Level Struct contians the data
    /// about how the level is constructed.
    /// </summary>
    public class LevelStruct 
    {
        public Dictionary<int, List<GameObject>> HexDictionary;

        public LevelStruct()
        {
            HexDictionary = new Dictionary<int, List<GameObject>>();
        }
    }
}
