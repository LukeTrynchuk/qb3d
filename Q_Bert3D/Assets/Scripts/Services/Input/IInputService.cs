using System;
using GreenApple.Poke.Core.Services;

namespace FireBullet.QBert.Services
{
    /// <summary>
    /// The IInputService interface is a contract
    /// that all input services must abide to.
    /// 
    /// An input service is responsible for detecting
    /// all user input and dispatch event for the input.
    /// </summary>
    public interface IInputService : IService
    {
        event Action OnUserTappedScreen;
    }
}
