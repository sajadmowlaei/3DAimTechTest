using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLookInput : MonoBehaviour
{
    public InputAction mouseLookInput;
    public float XSensitivity = 5f;
    public float YSensitivity = 5f;
    private Quaternion _characterTargetRot;
    private Quaternion _cameraTargetRot;
    private void OnEnable()
    {
        mouseLookInput.Enable();
    }

    private void OnDisable()
    {
        mouseLookInput.Disable();
    }
    public void Init(Transform character, Transform camera)
    {
        _characterTargetRot = character.localRotation;
        _cameraTargetRot = camera.localRotation;
    }
    public void LookRotation(Transform character, Transform camera)
    {
        float yRot = mouseLookInput.ReadValue<Vector2>().x * XSensitivity;;
        float xRot = mouseLookInput.ReadValue<Vector2>().x * YSensitivity;;
        
        Debug.Log("yRot : "+yRot.ToString()+" xRot : "+xRot.ToString());
        _characterTargetRot *= Quaternion.Euler (0f, yRot, 0f);
        _cameraTargetRot *= Quaternion.Euler (-xRot, 0f, 0f);

        character.localRotation = _characterTargetRot;
        camera.localRotation = _cameraTargetRot;
        
        //UpdateCursorLock();
    }
    
}
