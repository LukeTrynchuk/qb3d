using NUnit.Framework;
using FireBullet.QBert.Services;
using System;

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
    }
}
