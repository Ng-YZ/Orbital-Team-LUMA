using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //for scene managmement at run-time
using UnityEngine.UI;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public int score = 0;
    public int highscore = 0; //new 24/07
    private Scene scene;

    public TextMeshProUGUI scoreText;

    void Start() 
    {
        //new 24/07
        scene = SceneManager.GetActiveScene();

        if (scene.name == "Changi") {
            highscore = PlayerPrefs.GetInt("Highscore 1");
        } else if (scene.name == "GBTB") {
            highscore = PlayerPrefs.GetInt("Highscore 2");
        } else if (scene.name == "Sentosa") {
            highscore = PlayerPrefs.GetInt("Highscore 3");
        } else if (scene.name == "Heritage") {
            highscore = PlayerPrefs.GetInt("Highscore 4");
        }
    }
  
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
