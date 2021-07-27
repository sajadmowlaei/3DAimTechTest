using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private PlayerMoveInput _playerMoveInput;
        private CharacterController _characterController;
        [SerializeField]
        private float moveSpeed = 3;
        private Camera _camera;
        //private PlayerLookInput _lookInput;
        private MouseLook _mouseLook;
        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _playerMoveInput = GetComponent<PlayerMoveInput>();
            _camera = Camera.main;
            
            
            //_lookInput = GetComponent<PlayerLookInput>();
            //_lookInput.Init(transform,_camera.transform);
           
            
            _mouseLook = new MouseLook();
            _mouseLook.Init(transform,_camera.transform);
        }
        private void Update()
        {

            _mouseLook.LookRotation(transform,_camera.transform);
            //_lookInput.LookRotation(transform,_camera.transform);

            Vector3 moveDirectionForward = transform.forward * _playerMoveInput.verticalInput;
            Vector3 moveDirectionSide = transform.right * _playerMoveInput.horizontalInput;
            
            Vector3 direction = (moveDirectionForward + moveDirectionSide).normalized;
            Vector3 distance = direction * (moveSpeed * Time.deltaTime);

            _characterController.Move (distance);
        }
    }
}
