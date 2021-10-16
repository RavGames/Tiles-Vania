﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float enemySpeed = 1f;

    private Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if(IsFacingRight())
        {
            rigidbody2D.velocity = new Vector2(enemySpeed, 0f);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(-enemySpeed, 0f);
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rigidbody2D.velocity.x)), 1f);
        Debug.Log("enemy Scale change" + transform.localScale);
    }
}
