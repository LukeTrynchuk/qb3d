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
        public GameObject HexPrefab { get { return m_hexPrefab; }}
        public LevelStruct LevelData { get { return m_levelStruct; } }
        #endregion

        #region Private Variables
        private LevelStruct m_levelStruct = new LevelStruct();
        private GameObject m_hexPrefab;
        #endregion

        #region Main Methods
        public void GenerateLevel(int numberOfRows)
        {
            if (numberOfRows <= 0)
                throw new System.ArgumentOutOfRangeException("Number of Rows must be greater than 0");

            ValidateData();
            ResetLevelData();
            CreateLevel(numberOfRows);
        }

		private void Awake()
		{
            LoadHexPrefab();
		}
		#endregion

		#region Utility Methods
        private void ValidateData()
        {
            if (m_hexPrefab == null) LoadHexPrefab();
        }

		private void CreateLevel(int numberOfRows)
        {
            for (int i = 1; i <= numberOfRows; i++)
            {
                CreateRow(i);
            }
        }

        private void CreateRow(int rowNumber)
        {
            InitializeDictionaryRow(rowNumber);
            int numberOfHexesToCreate = rowNumber * 6;

            for (int i = 0; i < numberOfHexesToCreate; i++)
            {
                m_levelStruct.HexDictionary[rowNumber].Add(null);
            }
        }
        #endregion

        #region Low Level Functions
        private void InitializeDictionaryRow(int rowNumber)
        {
            m_levelStruct.HexDictionary.Add(rowNumber, new List<GameObject>());
        }

        private void ResetLevelData()
        {
            m_levelStruct.HexDictionary.Clear();
        }

        private List<GameObject> GetHexList()
        {
            List<GameObject> m_returnList = new List<GameObject>();
            foreach (KeyValuePair<int, List<GameObject>> entry in m_levelStruct.HexDictionary)
                m_returnList.AddRange(entry.Value);
            return m_returnList;
        }

        private void LoadHexPrefab()
        {
            m_hexPrefab = (GameObject)Resources.Load("Prefabs/Hexagon");
        }
        #endregion
    }
}
