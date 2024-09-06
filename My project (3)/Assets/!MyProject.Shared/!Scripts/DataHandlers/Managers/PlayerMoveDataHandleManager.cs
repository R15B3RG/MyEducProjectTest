using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class PlayerMoveDataHandleManager
{
    public static event Action<Vector2> OnPlayerMove;
    public static void PlayerMove(Vector2 dir) => OnPlayerMove.Invoke(dir); //Direction of movment


    public static event Action<bool> OnPlayerRun;
    public static void PlayerRun(bool isPressed) => OnPlayerRun.Invoke(isPressed); //If button is pressed, the player runs


    public static event Action<bool> OnPlayerJump;
    public static void PlayerJump(bool isPressed) => OnPlayerJump.Invoke(isPressed);  //If button is pressed, the player jumps
}
