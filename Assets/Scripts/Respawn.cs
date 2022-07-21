using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    public PlayerInteraction playerInteract;


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerInteract.score < 400) 
            {
                playerInteract.score = 0;
            }

            else 
            {
                playerInteract.score -= 400;
            }
        
       
       
       
       
        Debug.Log(playerInteract.score);

        playerInteract.scoreText.text = playerInteract.score.ToString();

        player.transform.position = respawnPoint.transform.position;
        }
        
    }
    

}
