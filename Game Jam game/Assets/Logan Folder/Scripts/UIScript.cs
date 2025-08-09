using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused = false;
    void Start()
    {
        // Limits fps to 60
        Application.targetFrameRate = 60;

        if (pauseMenu) pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (pauseMenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isPaused) { Time.timeScale = 0; pauseMenu.SetActive(true); isPaused = true;  }
                else if (isPaused) { Time.timeScale = 1; pauseMenu.SetActive(false); isPaused = false; }
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void MainMenu()
    {
        // SceneManager.LoadScene();
        // Insert location to scene for game
    }

    public void StartGame()
    {
        // SceneManager.LoadScene();
        // Insert location to scene for game
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
