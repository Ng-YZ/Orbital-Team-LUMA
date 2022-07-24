using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowBallController : MonoBehaviour
{
    Animator myAnim;
    
    void Start()
    {
        myAnim = GetComponent<Animator>();
        myAnim.SetBool("isContact", false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") 
        {

            myAnim.SetBool("isContact", true);
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
           myAnim.SetBool("isContact", false);
        }
    }
}
