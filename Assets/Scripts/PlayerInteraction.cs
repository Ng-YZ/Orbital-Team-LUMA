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
        //restart the scene if the other object is a hazard


        //enemy condition isn't needed anymore because now the player respawns at a specific point when hit by an enemy
        if(other.gameObject.tag == "Hazards" /*|| other.gameObject.tag == "Enemy"*/)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    
        }

        //go to next scene if the other object is a portal
        if(other.gameObject.tag == "Portal")
        {
            //Debug.Log("Portal here");
            SceneManager.LoadScene(sceneName:"NationalGallery");
    
        }


         if(other.gameObject.tag == "Painting1")
        {
            SceneManager.LoadScene(sceneName:"Changi"); 
    
        }

        if(other.gameObject.tag == "Painting2")
        {
            SceneManager.LoadScene(sceneName:"GBTB"); 
    
        }

        if(other.gameObject.tag == "Painting3")
        {
            SceneManager.LoadScene(sceneName:"Scene3"); 
    
        }

        if(other.gameObject.tag == "Painting4")
        {
            SceneManager.LoadScene(sceneName:"Scene4"); 
    
        }

        if(other.gameObject.tag == "CollectibleAccess")
        {
            SceneManager.LoadScene(sceneName:"CollectibleGallery");

        }
        if(other.gameObject.tag == "GalleryAccess")
        {
            SceneManager.LoadScene(sceneName:"NationalGallery");

        }
        
        
    }
    
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
