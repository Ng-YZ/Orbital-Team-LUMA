using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{  
    Animator ButtonPress;
    //private int BlockIndex = 0;

    [SerializeField] private GameObject[] Blocks;
    [SerializeField] private GameObject Sign;
    [SerializeField] private GameObject Interactable;
    
    void Start()
    {
        ButtonPress = GetComponent<Animator>();
        ButtonPress.SetBool("isContact", false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player") 
        {

            ButtonPress.SetBool("isContact", true);
            
            foreach(GameObject block in Blocks) 
            {
                block.SetActive(false);
            }

            Sign.SetActive(false);
            Interactable.SetActive(false);
            
        }
    }
}
