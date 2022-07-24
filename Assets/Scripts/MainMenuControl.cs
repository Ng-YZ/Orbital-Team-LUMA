using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public void PlayGame() 
    {
        SceneManager.LoadScene(sceneName:"NationalGallery"); 
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
