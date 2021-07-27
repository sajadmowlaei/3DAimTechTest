using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook
{

    public float XSensitivity = 5f;
    public float YSensitivity = 5f;
        
    private Quaternion _characterTargetRot;
    private Quaternion _cameraTargetRot;
    
    private bool lockCursor = true;
    private bool _cursorIsLocked = true;
    
    public void Init(Transform character, Transform camera)
    {
        _characterTargetRot = character.localRotation;
        _cameraTargetRot = camera.localRotation;
    }
    public void LookRotation(Transform character, Transform camera)
    {
        float yRot = Input.GetAxis("Mouse X") * XSensitivity;
        float xRot = Input.GetAxis("Mouse Y") * YSensitivity;

        _characterTargetRot *= Quaternion.Euler (0f, yRot, 0f);
        _cameraTargetRot *= Quaternion.Euler (-xRot, 0f, 0f);
        
        character.localRotation = _characterTargetRot;
        camera.localRotation = _cameraTargetRot;
        

        UpdateCursorLock();
    }
    
    private void UpdateCursorLock()
    {
        if (lockCursor)
            InternalLockUpdate();
    }
    private void InternalLockUpdate()
    {
        
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            _cursorIsLocked = false;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            _cursorIsLocked = true;
        }

        if (_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (!_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
