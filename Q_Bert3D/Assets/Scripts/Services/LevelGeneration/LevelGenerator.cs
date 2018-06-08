using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace FireBullet.QBert.Services
{
    /// <summary>
    /// The Level Generator is an implementation of the ILevelGenerator
    /// service which generates levels for the game.
    /// </summary>
    public class LevelGenerator : MonoBehaviour
    {
        #region Public Variables
        public List<GameObject> Hexes { get { return m_hexes; } }
        #endregion

        #region Private Variables
        private List<GameObject> m_hexes = new List<GameObject>();
        #endregion

        #region Main Methods
        public void GenerateLevel(int numberOfRows)
        {
            if (numberOfRows <= 0)
                throw new System.ArgumentOutOfRangeException("Number of Rows must be greater than 0");

            CreateLevel(numberOfRows);
        }
        #endregion

        #region Utility Methods
        private void CreateLevel(int numberOfRows)
        {
            int numberOfHexesToCreate = numberOfRows * 6;
            for (int i = 0; i < numberOfHexesToCreate; i++)
            {
                m_hexes.Add(null);
            }
        }
        #endregion
    }
}
