using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
        // Start is called before the first frame update
       public void PlayGame() 
    {
        SceneManager.LoadScene(sceneName:"NationalGallery"); 
    }

    public void Options()
    {
        SceneManager.LoadScene(sceneName:"Options"); 
    }

    public void QuitGame() 
    {
        //print("quit!");
        Application.Quit();
    }
}
