using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objectsToEnable;
    [SerializeField] private GameObject _pauseMenuUi;
    private bool _enableObjects = false;
    private const string _mainMenuName = "MainMenu";
    [SerializeField] private Button _resumeGame;
    [SerializeField] private Button _mainMenu;
    [SerializeField] private Button _quitGame;

    

    private void Awake()
    {
        _resumeGame.onClick.AddListener(OnResumeGame);
        _mainMenu.onClick.AddListener(OnGoToMainMenu);
        _quitGame.onClick.AddListener(OnQuitGame);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _enableObjects = !_enableObjects;
            _objectsToEnable.ForEach(go => go.SetActive(_enableObjects));
            Time.timeScale = 0;
        }
    }

    private void OnResumeGame()
    {
        _enableObjects = !_enableObjects;
        _objectsToEnable.ForEach(go => go.SetActive(_enableObjects));
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    private void OnGoToMainMenu()
    {
        SceneManager.LoadScene(_mainMenuName);
    }

    private void OnQuitGame()
    {
#if UNITY_EDITOR
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
        }
#endif
        Application.Quit();
    }

}
