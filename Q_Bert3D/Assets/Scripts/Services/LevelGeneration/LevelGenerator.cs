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
        public List<GameObject> Hexes { get { return GetHexList(); } }
        public LevelStruct LevelData { get { return m_levelStruct; }}
        #endregion

        #region Private Variables
        private LevelStruct m_levelStruct = new LevelStruct();
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
            for (int i = 1; i <= numberOfRows; i++)
            {
                CreateRow(i);
            }
        }

        private void CreateRow(int rowNumber)
        {
            m_levelStruct.HexDictionary.Add(rowNumber, new List<GameObject>());
            int numberOfHexesToCreate = rowNumber * 6;
            
            for (int i = 0; i < numberOfHexesToCreate; i++)
            {
                m_levelStruct.HexDictionary[rowNumber].Add(null);
            }
        }

        private List<GameObject> GetHexList()
        {
            List<GameObject> m_returnList = new List<GameObject>();
            foreach (KeyValuePair<int, List<GameObject>> entry in m_levelStruct.HexDictionary)
                m_returnList.AddRange(entry.Value);
            return m_returnList;
        }
        #endregion
    }
}
