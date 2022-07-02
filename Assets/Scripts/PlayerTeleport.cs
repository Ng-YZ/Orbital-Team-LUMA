using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
         if(collision.CompareTag("Teleporter"))
        {
            currentTeleporter = null;

        }

    }
}
