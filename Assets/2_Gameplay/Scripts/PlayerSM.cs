using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay
{
    public class PlayerSM
    {
        private IPlayerState _currentState;
        private int _jumpsDone = 0;
        private readonly int _maxJumps = 2;

        private readonly Character _character;
        private readonly MonoBehaviour _runner;
        private readonly InputActionReference _moveInput;
        private readonly float _airborneMultiplier;

        public PlayerSM(Character character, MonoBehaviour runner, InputActionReference moveInput, float airborneMultiplier)
        {
            _character = character;
            _runner = runner;
            _moveInput = moveInput;
            _airborneMultiplier = airborneMultiplier;

            ChangeState(new Walk(_character, _moveInput, _airborneMultiplier));
        }

        public void ChangeState(IPlayerState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        public void HandleInput(InputAction.CallbackContext ctx)
        {
            if (ctx.action.name.ToLower().Contains("jump"))
            {
                if (CanJump())
                {
                    ChangeState(new Jump(_character, this, _runner));
                }
            }
            else
            {
                _currentState?.HandleInput(ctx);
            }
        }

        public void Update()
        {
            _currentState?.Update();
        }

        public bool CanJump() => _jumpsDone < _maxJumps;
        public void RegisterJump() => _jumpsDone++;
        public void ResetJumps() => _jumpsDone = 0;
    }
}
