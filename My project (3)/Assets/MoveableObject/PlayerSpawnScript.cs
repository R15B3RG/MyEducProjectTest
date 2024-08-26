using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    [SerializeField] private Vector3 _spawnPosition;

    void Start()
    {
        Awake();
    }

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        SpawnPlayer();
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void SpawnPlayer()
    {
        _spawnPosition = transform.position;

        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            Instantiate(_player, _spawnPosition, Quaternion.identity);
        }
    }
}
