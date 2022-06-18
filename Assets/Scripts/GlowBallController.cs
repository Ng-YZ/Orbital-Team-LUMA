using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowBallController : MonoBehaviour
{
    //private bool isContact = false;
    Animator myAnim;
    

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        myAnim.SetBool("isContact", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.tag == "Player") 
        {
            //isContact = true;
            myAnim.SetBool("isContact", true);
            
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
           //isContact = false;
           myAnim.SetBool("isContact", false);
        }
        
    }
}
