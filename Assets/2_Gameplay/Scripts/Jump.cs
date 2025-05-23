using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay
{
    public class Jump : IPlayerState
    {
        private readonly Character _character;
        private readonly PlayerSM _stateMachine;
        private readonly MonoBehaviour _runner;
        private Coroutine _jumpCoroutine;

        public Jump(Character character, PlayerSM stateMachine, MonoBehaviour runner)
        {
            _character = character;
            _stateMachine = stateMachine;
            _runner = runner;
        }

        public void Enter()
        {
            _stateMachine.RegisterJump();
            _jumpCoroutine = _runner.StartCoroutine(_character.Jump());
        }

        public void Exit()
        {
            if (_jumpCoroutine != null)
                _runner.StopCoroutine(_jumpCoroutine);
        }

        public void HandleInput(InputAction.CallbackContext ctx) { }

        public void Update() { }
    }
}
