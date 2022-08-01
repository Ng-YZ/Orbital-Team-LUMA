using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    bool isFalling = false;
    float downSpeed = 0;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            isFalling = true;
            transform.DetachChildren();
            Destroy(gameObject, 1.5f);
        }
        
    }

    void Update()
    {
        if (isFalling)
        {
            downSpeed += Time.deltaTime/12;
            transform.position = new Vector3(transform.position.x, transform.position.y - downSpeed, transform.position.z);
        }
        
    }
}
