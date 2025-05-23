using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay
{
    public class Walk : IPlayerState
    {
        private readonly Character _character;
        private readonly InputActionReference _moveInput;
        private readonly float _airborneMultiplier;

        public Walk(Character character, InputActionReference moveInput, float airborneMultiplier)
        {
            _character = character;
            _moveInput = moveInput;
            _airborneMultiplier = airborneMultiplier;
        }

        public void Enter()
        {
            // Nada especial al entrar
        }

        public void Exit()
        {
            _character.SetDirection(Vector3.zero);
        }

        public void HandleInput(InputAction.CallbackContext ctx)
        {
            Vector3 direction = ctx.ReadValue<Vector2>().ToHorizontalPlane();
            _character.SetDirection(direction);
        }

        public void Update() { }
    }
}

