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
    [SerializeField] Vector2 deathKick = new Vector2(1f, 25f);
    float gravityRigidbody2d;

    //state
    private bool isAlive = true;


    //components
    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private CapsuleCollider2D bodyCollider2d;
    private BoxCollider2D myFeet;

    //msg then methods
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        bodyCollider2d = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
        gravityRigidbody2d = rigidbody2d.gravityScale;
    }

    private void Update()
    {

        if (!isAlive) { return; }
        Run();
        ClimbLadder();
        Jump();
        FlipSprite();
        Die();
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
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Climbing")))
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
            if(myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
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



    private void Die()
    {
        if (bodyCollider2d.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            isAlive = false;
            animator.SetTrigger("Die");
            rigidbody2d.velocity = deathKick;
        }
    }




}//CLASS
