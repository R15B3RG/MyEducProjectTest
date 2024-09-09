using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraInputManager : MonoBehaviour
{
    private void OnRotate(InputValue value)
    {
        PlayerCameraDataHandlerManager.Rotate(value.Get<Vector2>());
    }
}
