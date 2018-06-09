using UnityEngine;
using System.Collections.Generic;
using GreenApple.Poke.Core.Services;

namespace FireBullet.QBert.Services
{
    /// <summary>
    /// The Level Generator is an implementation of the ILevelGenerator
    /// service which generates levels for the game.
    /// </summary>
    public class LevelGenerator : MonoBehaviour , ILevelGenerator
    {
        #region Public Variables
        public List<GameObject> Hexes => GetHexList();
        public GameObject HexPrefab => m_hexPrefab; 
        public LevelStruct LevelData => m_levelStruct; 
        #endregion

        #region Private Variables
        private LevelStruct m_levelStruct = new LevelStruct();
        private GameObject m_hexPrefab;

        private const float LAYER_HEIGHT_DIFFERENCE = 0.48f;
        private const float LAYER_EDGE_HEX_DISTANCE = 0.85f;
        #endregion

        #region Main Methods
        public void GenerateLevel(int numberOfRows)
        {
            if (numberOfRows <= 0)
                throw new System.ArgumentOutOfRangeException("Number of Rows must be greater than 0");

            ValidateData();
            ResetLevelData(numberOfRows);
            CreateLevel(numberOfRows);
        }

		private void Awake() 
        {
            RegisterService();
			LoadHexPrefab();
        }
		#endregion

		#region Utility Methods
        private void ValidateData() => m_hexPrefab = m_hexPrefab ?? LoadHexPrefab();

		private void CreateLevel(int numberOfRows)
        {
            GenerateKeyEdgeHexagons(numberOfRows);
        }

        private void GenerateKeyEdgeHexagons(int numberOfRows)
        {
            Vector2 headingVector = new Vector2(0, 1);

            for (int i = 0; i < 6; i++)
            {
				GenerateKeyEdge(numberOfRows, headingVector);
                headingVector = headingVector.Rotate(60f);
            }
        }

        private void GenerateKeyEdge(int numberOfRows, Vector2 heading)
        {
            for (int i = 1; i <= numberOfRows; i++)
            {
                Vector3 position = GenerateKeyEdgeHexPosition(i, heading);
                GenerateFillins(numberOfRows, i + 1, heading, position);
                CreateHex(position, i);
            }
        }

        private void GenerateFillins(int numberOfRows, int rowNumber, Vector2 headingVector, Vector3 startPosition)
        {
            if (rowNumber > numberOfRows) return;

            headingVector = headingVector.Rotate(60f);
            Vector3 lastPosition = startPosition;

            for (int i = 0; rowNumber + i <= numberOfRows; i++)
            {
                Vector3 position = GenerateFillinHexPosition(rowNumber + i, headingVector, lastPosition);
                lastPosition = position;
                CreateHex(position, rowNumber + i);
            }
        }
        #endregion

        #region Low Level Functions
        private void InitializeDictionaryRow(int rowNumber) => 
            m_levelStruct.HexDictionary.Add(rowNumber, new List<GameObject>());

        private void ResetLevelData(int numberOfRows) 
        {
			m_levelStruct.HexDictionary.Clear();
            for (int i = 0; i < numberOfRows; i++)
            {
                m_levelStruct.HexDictionary.Add(i + 1, new List<GameObject>());
            }
        }

        private List<GameObject> GetHexList()
        {
            List<GameObject> m_returnList = new List<GameObject>();
            foreach (KeyValuePair<int, List<GameObject>> entry in m_levelStruct.HexDictionary)
                m_returnList.AddRange(entry.Value);
            return m_returnList;
        }

        private Vector3 GenerateKeyEdgeHexPosition(int rowNumber, Vector2 heading)
        {
            Vector3 position = transform.position;

            position.y = -LAYER_HEIGHT_DIFFERENCE * rowNumber;
            position += new Vector3(heading.x * LAYER_EDGE_HEX_DISTANCE * rowNumber,
                                    0, 
                                    heading.y * LAYER_EDGE_HEX_DISTANCE * rowNumber);

            return position;
        }

        private Vector3 GenerateFillinHexPosition(int rowNumber, Vector2 heading, Vector3 startPosition)
        {
            Vector3 position = startPosition;

            position.y = -LAYER_HEIGHT_DIFFERENCE * rowNumber;
            position += new Vector3(heading.x * LAYER_EDGE_HEX_DISTANCE,
                                    0,
                                    heading.y * LAYER_EDGE_HEX_DISTANCE);

            return position;
        }

        private void CreateHex(Vector3 position, int LayerNumber)
        {
            GameObject hexObject = Instantiate(m_hexPrefab, position, Quaternion.identity);
            hexObject.name = "Hexagon";

            m_levelStruct.HexDictionary[LayerNumber].Add(hexObject);
        }

        private GameObject LoadHexPrefab() => (GameObject)Resources.Load("Prefabs/Hexagon");

        public void RegisterService() => ServiceLocator.Register<ILevelGenerator>(this);
        #endregion
    }
}
