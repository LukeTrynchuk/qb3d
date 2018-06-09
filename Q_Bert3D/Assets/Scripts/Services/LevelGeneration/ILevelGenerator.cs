using UnityEngine;
using GreenApple.Poke.Core.Services;

namespace FireBullet.QBert.Services
{
    /// <summary>
    /// The ILevelGenerator interface defines how the 
    /// level generator works.
    /// </summary>
    public interface ILevelGenerator : IService
    {
        void GenerateLevel(int numberOfRows);
    }
}
