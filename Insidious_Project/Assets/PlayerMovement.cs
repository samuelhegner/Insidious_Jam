using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D rb;

    public float forceScale;
    public float maxVelocity;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetMouseButtonDown(0))
        {

            Vector2 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 Direction = targetPos - (Vector2)transform.position;

            Direction.Normalize();

            rb.AddForce(Direction * forceScale, ForceMode2D.Impulse);


            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);

        }

    }

}
