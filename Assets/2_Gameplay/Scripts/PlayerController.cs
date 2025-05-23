using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay
{
    
        [RequireComponent(typeof(Character))]
        public class PlayerController : MonoBehaviour
        {
            [SerializeField] private InputActionReference moveInput;
            [SerializeField] private InputActionReference jumpInput;
            [SerializeField] private float airborneSpeedMultiplier = 0.5f;

            private Character _character;
            private PlayerSM _stateMachine;

            private void Awake()
            {
                _character = GetComponent<Character>();
                _stateMachine = new PlayerSM(_character, this, moveInput, airborneSpeedMultiplier);
            }

            private void OnEnable()
            {
                moveInput.action.started += _stateMachine.HandleInput;
                moveInput.action.performed += _stateMachine.HandleInput;
                moveInput.action.canceled += _stateMachine.HandleInput;
                jumpInput.action.performed += _stateMachine.HandleInput;
            }

            private void OnDisable()
            {
                moveInput.action.started -= _stateMachine.HandleInput;
                moveInput.action.performed -= _stateMachine.HandleInput;
                moveInput.action.canceled -= _stateMachine.HandleInput;
                jumpInput.action.performed -= _stateMachine.HandleInput;
            }

            private void Update()
            {
                _stateMachine.Update();
            }

            private void OnCollisionEnter(Collision collision)
            {
                foreach (var contact in collision.contacts)
                {
                    if (Vector3.Angle(contact.normal, Vector3.up) < 5f)
                    {
                        _stateMachine.ResetJumps();
                        _stateMachine.ChangeState(new Walk(_character, moveInput, airborneSpeedMultiplier));
                    }
                }
            }
        }
}
