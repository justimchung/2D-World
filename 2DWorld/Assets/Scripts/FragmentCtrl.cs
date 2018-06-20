using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentCtrl : MonoBehaviour {
    private Rigidbody2D rb;
    public Vector2 JumpForce;
    public float destroyDelay;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(JumpForce);
        Destroy(gameObject, destroyDelay);
	}
}
