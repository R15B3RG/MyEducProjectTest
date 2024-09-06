using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveInputManager : MonoBehaviour
{
    private void OnMove(InputValue value)
    {
        PlayerMoveDataHandleManager.PlayerMove(value.Get<Vector2>()); //Collects the data for player movement
    }

    private void OnRun(InputValue value)
    {
        PlayerMoveDataHandleManager.PlayerRun(value.isPressed); //Checks if the value is true or false
    }

    private void OnJump(InputValue value)
    {
        PlayerMoveDataHandleManager.PlayerJump(value.isPressed); //Checks if the value is true or false
    }
}
