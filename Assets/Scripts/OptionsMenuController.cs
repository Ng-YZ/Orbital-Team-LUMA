using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenuController : MonoBehaviour
{
    //return to main menu
    public void ReturnMain() 
    {
        SceneManager.LoadScene(sceneName:"Main Menu");
    }
    
}
