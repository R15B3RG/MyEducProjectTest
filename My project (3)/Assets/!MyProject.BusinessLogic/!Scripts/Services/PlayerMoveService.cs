using System;
using UnityEngine;

[Serializable]

public class PlayerMoveService
{
    private Player _player;

    private CharacterController _characterController;

    [SerializeField] private float _moveSpeed = 5.0f;
    [SerializeField] private float _runSpeed = 8.0f;
    [SerializeField] private float _jumpHeight = 7.0f;

    private Vector2 _direction;
    private Vector3 _moveDirection;
    private bool _isRunning = false;
    private bool _isJumping = false;

    private float _gravity = 9.81f;
    public PlayerMoveService(Player player, CharacterController characterController)
    {
        _player = player;
        _characterController = characterController;
    }

    public void OnMove(Vector2 direction) => _direction = direction;
    public void OnRun(bool isRunning)
    {
        _isRunning = isRunning;

        Debug.Log("Is Running");
    }
    public void OnJump(bool isJumping)
    {
        _isJumping = isJumping;

        Debug.Log("Is Jumping");
    }

    public void PlayerMovement()
    {
        ApplyMovement();
        ApplyJump();
        ApplyGravity();

        if (!_characterController.enabled) return;

        _characterController.Move(_moveDirection * Time.deltaTime);
    }

    private void ApplyMovement()
    {
        Vector3 forward = _characterController.gameObject.transform.TransformDirection(Vector3.forward);
        Vector3 right = _characterController.gameObject.transform.TransformDirection(Vector3.right);

        float moveSpeed = _direction.y <= 0 ? _moveSpeed : _isRunning ? _runSpeed : _moveSpeed;

        Vector3 moveDirection = ((forward * _direction.y) + (right * _direction.x)) * moveSpeed;

        _moveDirection = new Vector3(moveDirection.x, _moveDirection.y, moveDirection.z);
    }
    private void ApplyJump()
    {
        if (!_isJumping) return;
        _isJumping = false;
        if (!_characterController.isGrounded) return;
        _moveDirection.y = _jumpHeight;
    }
    private void ApplyGravity()
    {
        if (_characterController.isGrounded) return;

        _moveDirection.y -= _gravity * Time.deltaTime;
    }
}
