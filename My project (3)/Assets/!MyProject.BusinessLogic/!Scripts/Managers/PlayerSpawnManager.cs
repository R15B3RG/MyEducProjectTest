using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    [SerializeField] private Vector3 _spawnPosition;

    void Awake()
    {

        SpawnPlayer();
    }

    

    void SpawnPlayer()
    {
       
       Instantiate(_player, _spawnPosition, Quaternion.identity);
        
    }

    
}
