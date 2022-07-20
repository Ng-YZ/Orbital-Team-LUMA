using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //for scene managmement at run-time
using UnityEngine.UI;
using TMPro;

public class CollectibleSystem : MonoBehaviour
{
    // new 20/7
    private GameObject book, leaf, gem, potion;

    void Start() {
        Scene scene = SceneManager.GetActiveScene();
        book = GameObject.Find("Collectible_Changi");
        leaf = GameObject.Find("Collectible_GBTB");
        gem = GameObject.Find("Collectible_Sentosa");
        potion = GameObject.Find("Collectible_Heritage");

        if (scene.name == "Changi") { //check scene name
            //if game object book is found and is not collected 
            if (book && PlayerPrefs.GetInt("L1Collect") != 1) { 
                Debug.Log(book.name);
                book.SetActive(true); //set item to be active
            } else if (PlayerPrefs.GetInt("L1Collect") == 1){ //if item collected in previous gameplay, set item inactive
                Debug.Log("Collected book"); 
                book.SetActive(false);
            } else {
                Debug.Log("No game object book found");
            }
        }

        if (scene.name == "GBTB") { //check scene name
            //if game object leaf is found and not collected
            if (leaf && PlayerPrefs.GetInt("L2Collect") != 1) {
                Debug.Log(leaf.name);
                leaf.SetActive(true);
            } else if (PlayerPrefs.GetInt("L2Collect") == 1){ //if collected, set item inactive
                Debug.Log("Collected leaf");
                leaf.SetActive(false);
            } else {
                Debug.Log("No game object leaf found");
            }
        }

        if (scene.name == "Sentosa") {
            if (gem && PlayerPrefs.GetInt("L3Collect") != 1) {
                Debug.Log(gem.name);
                gem.SetActive(true);
            } else if (PlayerPrefs.GetInt("L3Collect") == 1){
                Debug.Log("Collected gem");
                gem.SetActive(false);
            } else {
                Debug.Log("No game object gem found");
            }
        }

        if (scene.name == "Heritage") {
            if (potion && PlayerPrefs.GetInt("L4Collect") != 1) {
                Debug.Log(potion.name);
                potion.SetActive(true);
            } else if (PlayerPrefs.GetInt("L4Collect") == 1){
                Debug.Log("Collected potion");
                potion.SetActive(false);
            } else {
                Debug.Log("No game object potion found");
            }
        }
    }

    
}
