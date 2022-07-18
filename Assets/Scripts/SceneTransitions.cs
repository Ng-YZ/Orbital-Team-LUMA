using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Entered");
        if(other.gameObject.tag == "Player")
        {
            Time.timeScale = 0f;
            Timer.StopTimer();
            Debug.Log("Record : " + PlayerPrefs.GetFloat("Record"));
            Time.timeScale = 1f;
            StartCoroutine(LoadScene());
            
        }
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }

    
}
