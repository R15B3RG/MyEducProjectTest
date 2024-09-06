using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{


    [SerializeField] private Player _player = new();

    public Player PlayerStats => _player;

    [SerializeField] private PlayerMoveService _moveService;

    private CharacterController _characterController;

    private void Awake()
    {

        _characterController = GetComponent<CharacterController>();

        _moveService = new PlayerMoveService(_player, _characterController);
        
    }

    private void OnEnable()
    {
        PlayerMoveDataHandleManager.OnPlayerMove += _moveService.OnMove;
        PlayerMoveDataHandleManager.OnPlayerRun += _moveService.OnRun;

        

        PlayerMoveDataHandleManager.OnPlayerJump += _moveService.OnJump;

        
    }
    private void OnDisable()
    {
        PlayerMoveDataHandleManager.OnPlayerMove -= _moveService.OnMove;
        PlayerMoveDataHandleManager.OnPlayerRun -= _moveService.OnRun;
        PlayerMoveDataHandleManager.OnPlayerJump -= _moveService.OnJump;

    }

    private void Update()
    {
        _moveService.PlayerMovement();
        
    }
}
