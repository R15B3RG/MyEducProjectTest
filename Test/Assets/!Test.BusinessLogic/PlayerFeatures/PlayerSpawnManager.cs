using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnmanager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _spawnPosition;

    private void Awake()
    {
        GameObject pos = _spawnPosition;

        Instantiate(_player, pos.transform.position, Quaternion.identity);
    }
}
