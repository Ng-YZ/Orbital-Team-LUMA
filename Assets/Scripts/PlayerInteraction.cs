using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //for scene managmement at run-time
using UnityEngine.UI;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public int score = 0;
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

        //new 20/7
        if (collision.gameObject.name == "Collectible_Changi") {
            Destroy(collision.gameObject);
            PlayerPrefs.SetInt("L1Collect", 1);
        }

        if (collision.gameObject.name == "Collectible_GBTB") {
            Destroy(collision.gameObject);
            PlayerPrefs.SetInt("L2Collect", 1);
        }

        if (collision.gameObject.name == "Collectible_Sentosa") {
            Destroy(collision.gameObject);
            PlayerPrefs.SetInt("L3Collect", 1);
        }
        
        if (collision.gameObject.name == "Collectible_Heritage") {
            Destroy(collision.gameObject);
            PlayerPrefs.SetInt("L4Collect", 1);
        }
    }
    
}
