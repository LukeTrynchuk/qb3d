using UnityEngine;
using FireBullet.QBert.Services;
using GreenApple.Poke.Core.Services;

namespace FireBullet.QBert.General
{
    /// <summary>
    /// The Call Generate Level component will call the
    /// generate level method of the Generate Level Service.
    /// </summary>
    public class CallGenerateLevel : MonoBehaviour
    {
        #region Private Variables
        private ServiceReference<ILevelGenerator> m_levelGenerationService
                                = new ServiceReference<ILevelGenerator>();
        #endregion

        #region Main Methods
        public void GenerateLevel(int numberOfRows) => 
                m_levelGenerationService.Reference?.GenerateLevel(numberOfRows);
        #endregion
    }
}
