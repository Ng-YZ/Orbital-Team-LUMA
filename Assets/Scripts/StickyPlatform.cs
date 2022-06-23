using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  

public class StickyPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" /*|| collision.gameObject.name == "Enemy"*/)
        {
        
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" /*|| collision.gameObject.name == "Enemy"*/)
        {

            collision.gameObject.transform.SetParent(null);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D other)
    {
         if (other.gameObject.name == "Enemy")
        {
        
            other.gameObject.transform.SetParent(transform);
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {

            other.gameObject.transform.SetParent(null);
        }
    }
    */
}