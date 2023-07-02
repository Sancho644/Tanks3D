using UnityEngine;
using UnityEngine.InputSystem;

namespace Creatures.Player
{
    public class PlayerInputReader : MonoBehaviour
    {
        [SerializeField] private Player _player;
        
        public void OnVerticalMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<float>();
            _player.SetVerticalDirection(direction);
        }

        public void OnHorizontalMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<float>();
            _player.SetHorizontalDirection(direction);
        }
        
        public void OnFireAction(InputAction.CallbackContext context)
        {
            _player.FireAction();
        }
    }
}