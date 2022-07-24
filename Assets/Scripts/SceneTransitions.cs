using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName;
    private Scene scene;

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Entered");
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(LoadScene());
            if (sceneName == "NationalGallery") //when loading into national gallery from levels
            {
                Time.timeScale = 0f;
                Timer.StopTimer();
                // Debug.Log("Record L1 : " + PlayerPrefs.GetFloat("Timing L1"));
                // Debug.Log("Record L2 : " + PlayerPrefs.GetFloat("Timing L2"));
                // Debug.Log("Record L3 : " + PlayerPrefs.GetFloat("Timing L3"));
                // Debug.Log("Record L4 : " + PlayerPrefs.GetFloat("Timing L4"));
                Time.timeScale = 1f;
            }
        }
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }   
}
