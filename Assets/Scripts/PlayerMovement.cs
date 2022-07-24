using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 9f;
    public float jumpSpeed;
    public LayerMask platformMask; //specifies which game layers are platforms
    private Rigidbody2D _rb;
    private BoxCollider2D _collider;
    private Animator animator;
    private float xAxis;
    private bool facingRight;

    /*remove if things go south */
    public float gravity;
    public float jumpHeight = 20f;
    public float jumpTime = 0.5f;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); //returns the component of type Rigidbody2D 
        _collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        
        
        
    /*remove if things go south */
        gravity = (float) -20;
        Physics2D.gravity = new Vector2(0, gravity); 
        //gravity = (-2 * jumpHeight) / Mathf.Pow(jumpTime, 2);
        //jumpSpeed = -gravity * jumpTime;
    }

    private void Update()
    {
        GetMovementInputs();
        Move(); 
        Jump();

        if (!IsGrounded())
        {
            animator.SetBool("jump", true);
        }

        else
        {
            animator.SetBool("jump", false);
        }
    }

    
    private void Move()
    {
        //this is for movement
        _rb.velocity = new Vector2(xAxis * walkSpeed, _rb.velocity.y); //setting rigid body's velocity

        //this is for animation
        animator.SetFloat("walkingSpeed", Mathf.Abs(xAxis)); //modulus xAxis to prevent negative values from triggering this
                                                            //because the condition in Unity only says "walkingSpeed less than 0.01"

        if (xAxis > 0 && facingRight)
        {
            Flip();
        }

        else if (xAxis < 0 && !facingRight)
        {
            Flip();
        }
    }

    //controls the scale of the sprite and flips it accordingly
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 tempScale = transform.localScale; //saves the scale of the sprite, if not once you start to move your character will go back to its tiny original 1x1 size
        tempScale.x *= -1; //flips the sprite instead of the actual character
        transform.localScale = tempScale;
    }

    private void GetMovementInputs() 
    {
        xAxis = Input.GetAxisRaw("Horizontal"); //number from -1 to 1 depending on whether you press left/right or A/D keys
    }

    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && IsGrounded()) 
        {
           _rb.velocity = new Vector2(_rb.velocity.x, jumpSpeed);
        }
    }

    private bool IsGrounded()
    {
        Bounds bounds = _collider.bounds; //Bounds represents an axis aligned bounding box (box aligned with coordinate axes, fully enclosing some object)
        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(bounds.min.x, bounds.min.y), Vector2.down, 0.1f, platformMask); 
        //0.1f refers to the length of the ray

        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(bounds.max.x, bounds.min.y), Vector2.down, 0.1f, platformMask); 

        return (hitLeft || hitRight); //short-circuited "or"
    }
}
