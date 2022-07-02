using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //for scene managmement at run-time
using UnityEngine.UI;

using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coin") 
        {

            Destroy(collision.gameObject);
            score += 100;
            scoreText.text = score.ToString(); //1.18.56
            
            
        }

        if(collision.gameObject.tag == "Hurtbox") 
        {
            Destroy(collision.transform.parent.gameObject);
            score += 200;
            scoreText.text = score.ToString(); //1.18.56
            
        }

         if(collision.gameObject.tag == "Collectible") 
        {

            Destroy(collision.gameObject);
            
        }

    }


    void OnCollisionEnter2D(Collision2D other)
    {


        if(other.gameObject.tag == "Hazards")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    
        }

        /*if(other.gameObject.tag == "Painting2")
        {
            SceneManager.LoadScene(sceneName:"GBTB"); 
    
        }
        */

        if(other.gameObject.tag == "Painting3")
        {
            SceneManager.LoadScene(sceneName:"Scene3"); 
    
        }

        if(other.gameObject.tag == "Painting4")
        {
            SceneManager.LoadScene(sceneName:"Scene4"); 
    
        }

        
        
    }
    
}
