using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private bool playerDetected;
    public Dialogue dialogueScript;

    //detect trigger w player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //enable playerDetected and show indicator
        if(collision.tag == "Player")
         {
            playerDetected = true;
            dialogueScript.ToggleIndicator(playerDetected);
         }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.tag == "Player")
        {
            playerDetected = false;
            dialogueScript.ToggleIndicator(playerDetected);
            dialogueScript.EndDialogue(); //new line added
        }

       
    }

    private void Update()
    {
        if(playerDetected && Input.GetKeyDown(KeyCode.E))
        {
            dialogueScript.StartDialogue();
        }
    }
   
}
