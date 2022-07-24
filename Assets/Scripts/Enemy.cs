using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float attackSpeed = 4f;
    public float returnToNormal = 3f;

    //private variables
    Rigidbody2D myRigid;
    bool isAttack = false;
    Animator myAnim; 
    float timeElapsed = -1f;
    float dir = 1f;
    
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if(timeElapsed >= 0)
        {
            timeElapsed -= Time.deltaTime;
            //if attack has lapsed, then return to normal
            if(timeElapsed < 0)
            {
                isAttack = false;
                myAnim.SetBool("isAttack", false);
            }
        }

        if(isAttack)
        {
            myRigid.velocity = new Vector2(attackSpeed * dir, myRigid.velocity.y);
        } else {
            myRigid.velocity = new Vector2(moveSpeed * dir, myRigid.velocity.y); //x is the moveSpeed, y is the myRigid.velocity.y (those are the initial x-velocity and y-velocity)
        }
    
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag != "Player")
        {
            dir *= -1;
            transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        //handles the long-range detection of the player
        if(other.gameObject.tag == "Player") 
        {
            isAttack = true;
            myAnim.SetBool("isAttack", true);
            timeElapsed = returnToNormal;

            //check whether the player is in front or behind the enemy
            if(FindObjectOfType<PlayerMovement>().gameObject.transform.position.x > transform.position.x)
            {
                dir = 1;
            } else {
                dir = -1;
            }

            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * dir, transform.localScale.y, transform.localScale.z);
        }
    }
}
