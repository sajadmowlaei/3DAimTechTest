using UnityEngine;

namespace Player
{
    public class InputManager : MonoBehaviour
    {
        public float horizontalInput;
        public float verticalInput;
        private void Update()
        {
            horizontalInput = Input.GetAxis ("Horizontal");
            verticalInput = Input.GetAxis ("Vertical");
        }
    }
}
