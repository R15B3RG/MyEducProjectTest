using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerMoveDataHandleManager
{
    public static event Action<Vector2> OnMove;
    public static void Move(Vector2 move) => OnMove?.Invoke(move);


    public static event Action<bool> OnRun;
    public static void Run(bool btnPressed) => OnRun?.Invoke(btnPressed);


    public static event Action<bool> OnJump;

    public static void Jump(bool btnPressed) => OnJump?.Invoke(btnPressed);
}
