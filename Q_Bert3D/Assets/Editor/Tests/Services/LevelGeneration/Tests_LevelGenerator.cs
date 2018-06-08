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
        [TestCase(2, 12)]
        [TestCase(3, 18)]
        [TestCase(4, 24)]
        public void GenerateMap_CorrectNumberOfHexesCreated_MustBeCorrect(int numberOfRows, int expectedNumberOfHexes)
        {
            LevelGenerator generator = new LevelGenerator();

            generator.GenerateLevel(numberOfRows);

            Assert.AreEqual(generator.Hexes.Count, expectedNumberOfHexes);
        }
    }
}
