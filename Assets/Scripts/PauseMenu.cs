using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenuUI, timingButton;
    
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape)) {
            if(GamePaused) 
            {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        timingButton.SetActive(true);
        AudioListener.pause = false;
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        timingButton.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void LoadMenu() {
        SceneManager.LoadScene(sceneName: "Options");
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    public void QuitToMenu() {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene(sceneName:"Main Menu");
    }
}
