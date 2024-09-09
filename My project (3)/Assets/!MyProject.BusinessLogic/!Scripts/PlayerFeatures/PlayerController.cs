using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{


    [SerializeField] private Player _player = new();

    public Player PlayerStats => _player;

    [SerializeField] private PlayerMoveService _moveService;
    private PlayerRotateService _rotService;

    private CharacterController _characterController;
    [SerializeField] private Camera _playerCam;

    private void Awake()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _characterController = GetComponent<CharacterController>();

        _moveService = new PlayerMoveService(_player, _characterController);
        _rotService = new PlayerRotateService(_playerCam, gameObject);
        
    }

    private void OnEnable()
    {
        PlayerMoveDataHandlerManager.OnPlayerMove += _moveService.OnMove;
        PlayerMoveDataHandlerManager.OnPlayerRun += _moveService.OnRun;
        PlayerMoveDataHandlerManager.OnPlayerJump += _moveService.OnJump;

        PlayerCameraDataHandlerManager.OnRotate += _rotService.OnRotate;
        
    }
    private void OnDisable()
    {
        PlayerMoveDataHandlerManager.OnPlayerMove -= _moveService.OnMove;
        PlayerMoveDataHandlerManager.OnPlayerRun -= _moveService.OnRun;
        PlayerMoveDataHandlerManager.OnPlayerJump -= _moveService.OnJump;

        PlayerCameraDataHandlerManager.OnRotate -= _rotService.OnRotate;
    }

    private void Update()
    {
        _moveService.PlayerMovement();
        _rotService.PlayerCameraRotation();
    }
}
