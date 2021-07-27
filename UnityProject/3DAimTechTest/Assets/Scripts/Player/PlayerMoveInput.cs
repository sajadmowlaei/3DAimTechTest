using System;
using UnityEngine;
using UnityEngine.InputSystem;
namespace Player
{
    public class PlayerMoveInput : MonoBehaviour
    {
        public InputAction moveInput;
        
        public float horizontalInput;
        public float verticalInput;

        private void OnEnable()
        {
            moveInput.Enable();
        }

        private void OnDisable()
        {
            moveInput.Disable();
        }


        
        private void Update()
        {
            //Debug.Log(moveInput.ReadValue<Vector2>().ToString());
            Vector2 input = moveInput.ReadValue<Vector2>();
            horizontalInput = input.x;
            verticalInput = input.y;
            
            ///
            
            
//            horizontalInput = Input.GetAxis ("Horizontal");
            //          verticalInput = Input.GetAxis ("Vertical");
        }

    }
}
