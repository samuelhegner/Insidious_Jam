using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob_Player_Controller : MonoBehaviour {

Rigidbody2D rb;

	public float forceScale;
	
	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D>();

//		rb.AddForce(new Vector2(-0.1f, -0.9f) * 20, ForceMode2D.Impulse );

	}


	private void FixedUpdate() {

		if (Input.GetMouseButtonDown(0)) {

			Vector2 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			Vector2 Direction = targetPos - (Vector2) transform.position;

Direction.Normalize();

			rb.AddForce(Direction * forceScale, ForceMode2D.Impulse);
			
			
		}


	}


	private void OnCollisionEnter2D(Collision2D other) {
		rb.velocity = Vector2.zero;
	}


}
