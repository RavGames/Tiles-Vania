using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{
    //config...
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 3f;
    [SerializeField] float climbSpeed = 5f;
    float gravityRigidbody2d;

    //state
    private bool isAlive = true;


    //components
    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private Collider2D collider2D;

    //msg then methods
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        collider2D = GetComponent<Collider2D>();
        gravityRigidbody2d = rigidbody2d.gravityScale;
    }

    private void Update()
    {
        Run();
        ClimbLadder();
        Jump();
        FlipSprite();
    }

    private void Run()
    {
        float x = CrossPlatformInputManager.GetAxis("Horizontal") * runSpeed;// this value is between -1 and +1
        Vector2 playerVelocity = new Vector2(x, rigidbody2d.velocity.y);
        rigidbody2d.velocity = playerVelocity;


       bool playerHasHorizontalSpeed = Mathf.Abs(rigidbody2d.velocity.x) > Mathf.Epsilon;
        animator.SetBool("running", playerHasHorizontalSpeed);
    }

    
    private void ClimbLadder()
    {
        if (!collider2D.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            animator.SetBool("climbing", false);
            rigidbody2d.gravityScale = gravityRigidbody2d;
            return;
        }

        float y = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(rigidbody2d.velocity.x, y * climbSpeed);
        rigidbody2d.velocity = climbVelocity;
        rigidbody2d.gravityScale = 0;

        bool playerHasVertivalMovement = Mathf.Abs(rigidbody2d.velocity.y) > Mathf.Epsilon;
        animator.SetBool("climbing", playerHasVertivalMovement);
    }

    private void Jump()
    {
       

        if(CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            if(collider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
                rigidbody2d.velocity = jumpVelocity;
            }

            
        }
        
    }



    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = (Mathf.Abs(rigidbody2d.velocity.x) > Mathf.Epsilon);
        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rigidbody2d.velocity.x), 1f);
        }
    }

    


}//CLASS
