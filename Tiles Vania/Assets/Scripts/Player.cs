using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    private Rigidbody2D rigidbody2d;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Run();
    }

    private void Run()
    {
        float x = CrossPlatformInputManager.GetAxis("Horizontal") * runSpeed;// this value is between -1 and +1
        Vector2 playerVelocity = new Vector2(x, rigidbody2d.velocity.y);
        rigidbody2d.velocity = playerVelocity;

    }






}//CLASS
