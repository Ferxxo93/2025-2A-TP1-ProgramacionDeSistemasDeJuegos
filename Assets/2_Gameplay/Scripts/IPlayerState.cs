using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay
{
    public interface IPlayerState
    {
        void Enter();
        void Exit();
        void HandleInput(InputAction.CallbackContext ctx);
        void Update();
    }

}
