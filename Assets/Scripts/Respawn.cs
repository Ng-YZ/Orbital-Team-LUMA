using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    /*
    void OnColliderEnter2D(Collider2D other)
    {
        Debug.Log("Entered function");
        if (other.gameObject.tag == "Player")
        {
        player.transform.position = respawnPoint.transform.position;
        }
        Debug.Log("After transform");
    }
    */

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
        player.transform.position = respawnPoint.transform.position;
        }
        
    }
    

}
