using NUnit.Framework;
using FireBullet.QBert.Services;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Editor
{   
    public class Tests_LevelGenerator 
    {
        [TestCase(0)]
        [TestCase(15)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(-10)]
        [TestCase(3)]
        [TestCase(8)]
        [TestCase(-4)]
        [TestCase(-1000)]
        [TestCase(1000)]
        public void GenerateMap_InputRowParameter_MustBeGreaterThan0(int numberOfRows)
        {
            LevelGenerator generator = new LevelGenerator();

            if(numberOfRows <= 0)
            {
                Assert.That(() => generator.GenerateLevel(numberOfRows),
                            Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
			}
        }

        [TestCase(1, 6)]
        [TestCase(2, 18)]
        [TestCase(3, 36)]
        [TestCase(4, 60)]
        public void GenerateMap_CorrectNumberOfHexesCreated_MustBeCorrect(int numberOfRows, int expectedNumberOfHexes)
        {
            LevelGenerator generator = new LevelGenerator();

            generator.GenerateLevel(numberOfRows);

            Assert.AreEqual(expectedNumberOfHexes, generator.Hexes.Count);
        }

        [TestCase(1, new int[]{6})]
        [TestCase(2, new int []{6,12})]
        [TestCase(3, new int [] {6, 12, 18})]
        [TestCase(4, new int [] {6,12,18,24})]
        public void GenerateMap_InputRowParameter_CorrectNumberOfHexesPerLayer(int numberOfRows, params int[] expectedNumber)
        {
            LevelGenerator generator = new LevelGenerator();

            generator.GenerateLevel(numberOfRows);

            LevelStruct levelStruct = generator.LevelData;

            for (int i = 1; i <= numberOfRows; i++)
            {
                Assert.AreEqual(expectedNumber[i - 1], levelStruct.HexDictionary[i].Count);
            }
        }

        [TestCase(1, 6)]
        [TestCase(2, 18)]
        [TestCase(3, 36)]
        [TestCase(4, 60)]
        public void GenerateMap_DoubleLevelGeneration_HexesShouldBeOverwritten(int numberOfRows, int expectedNumber)
        {
            LevelGenerator generator = new LevelGenerator();

            generator.GenerateLevel(numberOfRows);
            generator.GenerateLevel(numberOfRows);

            Assert.AreEqual(expectedNumber, generator.Hexes.Count);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        public void GenerateMap_HexPrefab_DidLoad(int numberOfRows)
        {
            LevelGenerator generator = new LevelGenerator();
            generator.GenerateLevel(numberOfRows);
            Assert.AreNotSame(null, generator.HexPrefab);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        public void GenerateMap_Hexes_AreEqualToHexPrefab(int numberOfRows)
        {
            LevelGenerator generator = new LevelGenerator();
            generator.GenerateLevel(numberOfRows);

            foreach(GameObject go in generator.Hexes)
            {
                Assert.AreEqual(generator.HexPrefab.name, go.name);
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        public void GenerateMap_HexHeights_AreDifferentOnEachLayer(int numberOfRows)
        {
            LevelGenerator generator = new LevelGenerator();
            generator.GenerateLevel(numberOfRows);

            List<float> heightLayerList = new List<float>();

            foreach(KeyValuePair<int, List<GameObject>> value in generator.LevelData.HexDictionary)
            {
                heightLayerList.Add(value.Value[0].transform.position.y);
            }

            for (int i = 0; i < heightLayerList.Count - 1; i++)
            {
                for (int j = i + 1; j < heightLayerList.Count; j++)
                {
                    Assert.AreNotEqual(heightLayerList[i], heightLayerList[j]);
                }
            }
        }


        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        public void GenerateMap_HexHeights_EachLayerIsLowerThanTheLast(int numberOfRows)
        {
            LevelGenerator generator = new LevelGenerator();
            generator.GenerateLevel(numberOfRows);

            List<float> heightLayerList = new List<float>();

            foreach (KeyValuePair<int, List<GameObject>> value in generator.LevelData.HexDictionary)
            {
                heightLayerList.Add(value.Value[0].transform.position.y);
            }

            for (int i = 0; i < heightLayerList.Count - 1; i++)
            {
                for (int j = i + 1; j < heightLayerList.Count; j++)
                {
                    Assert.True(heightLayerList[i] > heightLayerList[j]);
                }
            }
        }

    }
}
