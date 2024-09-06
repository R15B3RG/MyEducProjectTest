using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Time = UnityEngine.Time;

public class EndPointManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objectsToEnable;

    [SerializeField] private GameObject _nextLevelUi;

    [SerializeField] private GameObject _endPoint;

    [SerializeField] private GameObject _textScript;

    [SerializeField] private Button _nextLevel;

    [SerializeField] private Vector3 _spawnPosition;

    private const string _nextLevelName = "Level2";

    private bool _enableObjects = false;

    private void Start()
    {
        _spawnPosition = transform.position;
    }

    private void Awake()
    {
        _nextLevel.onClick.AddListener(OnNextLevel);
    }

    private void Update()
    {
        
    }

    private void OnNextLevel()
    {
        SceneManager.LoadScene(_nextLevelName);

        Time.timeScale = 1;
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _enableObjects = !_enableObjects;
            _objectsToEnable.ForEach(go => go.SetActive(_enableObjects));
            Time.timeScale = 0;
        }
    }

}
