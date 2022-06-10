using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform); //sets the player as a child of the moving platform
        }
    }

    private void OnTriggerExit2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null); //remove the platform from being a parent of the child by setting the parent to null (no value)
        }
    }
}
