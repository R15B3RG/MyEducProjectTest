using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerCameraDataHandlerManager
{
    public static event Action<Vector2> OnRotate;

    public static void RotateCamera(Vector2 mouseRot) => OnRotate?.Invoke(mouseRot);
}
