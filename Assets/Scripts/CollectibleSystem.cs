using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;
using TMPro;

public class CollectibleSystem : MonoBehaviour
{
    private GameObject book, leaf, gem, potion;

    void Start() 
    {
        //PlayerPrefs.DeleteKey("L1Collect");
        Scene scene = SceneManager.GetActiveScene();
        book = GameObject.Find("Collectible_Changi");
        leaf = GameObject.Find("Collectible_GBTB");
        gem = GameObject.Find("Collectible_Sentosa");
        potion = GameObject.Find("Collectible_Heritage");

        if (scene.name == "Changi") 
        { //check scene name 
            if (book && PlayerPrefs.GetInt("L1Collect") != 1) { //if game object book is found and is not collected
                book.SetActive(true); 
            } else if (PlayerPrefs.GetInt("L1Collect") == 1) { //if item collected in previous gameplay, set item inactive
                book.SetActive(false);
            } else {
                Debug.Log("No game object book found");
            }
        }

        if (scene.name == "GBTB") 
        { 
            if (leaf && PlayerPrefs.GetInt("L2Collect") != 1) {
                leaf.SetActive(true);
            } else if (PlayerPrefs.GetInt("L2Collect") == 1) { 
                leaf.SetActive(false);
            } else {
                Debug.Log("No game object leaf found");
            }
        }

        if (scene.name == "Sentosa") 
        {
            if (gem && PlayerPrefs.GetInt("L3Collect") != 1) {
                gem.SetActive(true);
            } else if (PlayerPrefs.GetInt("L3Collect") == 1) {
                gem.SetActive(false);
            } else {
                Debug.Log("No game object gem found");
            }
        }

        if (scene.name == "Heritage") 
        {
            if (potion && PlayerPrefs.GetInt("L4Collect") != 1) {
                potion.SetActive(true);
            } else if (PlayerPrefs.GetInt("L4Collect") == 1) {
                potion.SetActive(false);
            } else {
                Debug.Log("No game object potion found");
            }
        }

        //To Display in Collectible Gallery which unique item(s) has been collected
        if (scene.name == "CollectibleGallery") {
            if (PlayerPrefs.GetInt("L1Collect") == 1) 
            {
                GameObject.Find("Collectible_L1 (1)").SetActive(false); //remove grey mask to display coloured collectible
            }

            if (PlayerPrefs.GetInt("L2Collect") == 1) 
            {
                GameObject.Find("Collectible_L2 (1)").SetActive(false);
            }

            if (PlayerPrefs.GetInt("L3Collect") == 1) 
            {
                GameObject.Find("Collectible_L3 (1)").SetActive(false);
            }

            if (PlayerPrefs.GetInt("L4Collect") == 1) 
            {
                GameObject.Find("Collectible_L4 (1)").SetActive(false);
            }
        }
    }

    
    
}
