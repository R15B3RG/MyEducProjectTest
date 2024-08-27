using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

        LoadNextScene();

    }

    public void LoadNextScene()
    {
        this.gameObject.SetActive(false);

        SceneManager.LoadScene(1);
    }


    public void QuitGame()
    {


        Application.Quit();
    }
}
