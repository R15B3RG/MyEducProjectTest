using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveInputManager : MonoBehaviour
{
    private void OnMove(InputValue value)
    {
        PlayerMoveDataHandlerManager.PlayerMove(value.Get<Vector2>()); //Collects the data for player movement
    }

    private void OnRun(InputValue value)
    {
        PlayerMoveDataHandlerManager.PlayerRun(value.isPressed); //Checks if the value is true or false
    }

    private void OnJump(InputValue value)
    {
        PlayerMoveDataHandlerManager.PlayerJump(value.isPressed); //Checks if the value is true or false
    }
}
