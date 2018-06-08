using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {
    public int speedBoost;
    public float jumpSpeed;
    public bool isGrounded;
    public LayerMask WhatIsGround;
    public Transform feet;
    public float boxWidth = 1f;
    public float boxHeight = 1f ;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private const int stateIdle = 0;
    private const int stateJump = 1;
    private const int stateRunning = 2;
    private const int stateFalling = 3;
    private const int stateHurt = -1;
    private bool isJumping = false;
    private bool canDoubleJump = false;
    public Transform leftBulletPos, rightBulletPos;
    public GameObject leftBullet, rightBullet;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        isGrounded = Physics2D.OverlapBox(feet.position,
            new Vector2(boxWidth, boxHeight), 360.0f, WhatIsGround);

        float playerSpeed = Input.GetAxisRaw("Horizontal");
        if (playerSpeed != 0)
        {
            MoveHorizontal(playerSpeed);
        }
        else
            StopMoving();


        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if(Input.GetButtonDown("Fire1"))
        {
            FireBullet();
        }

        if (rb.velocity.y < 0)
            showFalling();
	}

    private void FireBullet()
    {
        if(sr.flipX)
        {
            Instantiate(leftBullet, leftBulletPos.position,
            Quaternion.identity);
        }
        else
        {
            Instantiate(rightBullet, rightBulletPos.position,
                Quaternion.identity);
        }
    }

    private void showFalling()
    {
        anim.SetInteger("State", stateFalling);
    }

    void StopMoving()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        if(isJumping == false)
           anim.SetInteger("State", stateIdle);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(feet.position,
            new Vector3(boxWidth, boxHeight));
    }

    void MoveHorizontal(float speed)
    {
        if (speed < 0)
            sr.flipX = true;
        else if (speed > 0)
            sr.flipX = false;
        rb.velocity = new Vector2(speed * speedBoost, rb.velocity.y);
        if(isJumping == false)
            anim.SetInteger("State", stateRunning);
    }

    void Jump()
    {
        if(isGrounded)
        {
            isJumping = true;
            canDoubleJump = true;
            rb.AddForce(new Vector2(0, jumpSpeed));
            anim.SetInteger("State", stateJump);
        }
        else
        {
            if(canDoubleJump)
            {
                canDoubleJump = false;
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(new Vector2(0, jumpSpeed));
                anim.SetInteger("State", stateJump);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
