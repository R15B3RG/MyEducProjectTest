using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotateService
{
    private GameObject _playerObject;

    private Camera _playerCam;

    private float _lookSpeed = 0.1f;

    private float _xRotation = 0f;

    private Vector2 _mouseRotation;

    [SerializeField, Range(0, 100)] private float _sensitivity = 1f;

    private float _lookXLimit = 90f;

    public PlayerRotateService(Camera camera, GameObject playerObj)
    {
        _playerCam = camera;
        _playerObject = playerObj;

        Debug.Log($"Player Object is: {_playerObject.name}");
    }

    public void OnRotate(Vector2 mouseRot)
    {
        Debug.Log(mouseRot);

        _mouseRotation = mouseRot;
    }
    

    public void PlayerCameraRotation()
    {
        _lookSpeed *= _sensitivity;

        _xRotation += -_mouseRotation.y * _lookSpeed;

        _xRotation = Mathf.Clamp(_xRotation, -90, 90);

        Debug.Log(_xRotation);

        _playerCam.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);

        _playerObject.transform.rotation *= Quaternion.Euler(0, _mouseRotation.x * _lookSpeed, 0);

        
    }
}
