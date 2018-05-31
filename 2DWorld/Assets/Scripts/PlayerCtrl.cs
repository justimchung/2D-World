using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {
    public int speedBoost;
    public float jumpSpeed;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private const int stateIdle = 0;
    private const int stateJump = 1;
    private const int stateRunning = 2;
    private const int stateFalling = 3;
    private const int stateHurt = -1;
    private bool isJumping = false;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
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

        if (rb.velocity.y < 0)
            showFalling();
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
        isJumping = true;
        rb.AddForce(new Vector2(0, jumpSpeed));
        anim.SetInteger("State", stateJump);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isJumping = false;
    }
}
