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
    

    // Start is called before the first frame update
    void Start()
    {
        ButtonPress = GetComponent<Animator>();
        ButtonPress.SetBool("isContact", false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player") 
        {

            ButtonPress.SetBool("isContact", true);
            //Blocks[].SetActive(false);

            foreach(GameObject block in Blocks) 
            {
                block.SetActive(false);
            }

            Sign.SetActive(false);
            Interactable.SetActive(false);
            
        }
    }
}
