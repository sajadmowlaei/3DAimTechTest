using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private InputManager _inputManager;
        private CharacterController _characterController;
        [SerializeField]
        private float moveSpeed = 3;
        private Camera _camera;
        private MouseLook _mouseLook;
        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _inputManager = GetComponent<InputManager>();
            _camera = Camera.main;
            _mouseLook = new MouseLook();
            _mouseLook.Init(transform,_camera.transform);
        }
    
        private void Update()
        {

            _mouseLook.LookRotation(transform,_camera.transform);

            Vector3 moveDirectionForward = transform.forward * _inputManager.verticalInput;
            Vector3 moveDirectionSide = transform.right * _inputManager.horizontalInput;

            Vector3 direction = (moveDirectionForward + moveDirectionSide).normalized;
            Vector3 distance = direction * (moveSpeed * Time.deltaTime);

            _characterController.Move (distance);
        }
    }
}
