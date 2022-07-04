using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenuUI;
    
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
        Time.timeScale = 1f;
        GamePaused = false;
        MusicPlayerScript.objectMusic.GetComponent<AudioSource>().Play();
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        MusicPlayerScript.objectMusic.GetComponent<AudioSource>().Pause();
    }

    public void LoadMenu() {
        Debug.Log("Loading Menu.");
    }

    public void QuitToMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName:"Main Menu");
    }
}
