using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour {
    public float speed;
    Rigidbody2D rb;
    SpriteRenderer sr;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        setStartingDirection();
	}

    private void setStartingDirection()
    {
        sr.flipX = (speed > 0);
    }

    // Update is called once per frame
    void Update () {
        Move();
	}

    void Move()
    {
        Vector2 temp = rb.velocity;
        temp.x = speed;
        rb.velocity = temp;
    }
}
