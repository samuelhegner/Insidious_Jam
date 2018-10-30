using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    Rigidbody2D body;

    float hInput;
    float vInput;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        if (Mathf.Abs(body.velocity.y) < 10f)
        {
            VerticalStrave(speed * Time.deltaTime);
        }    


        if(Mathf.Abs(body.velocity.x) < 10f){
            HorizontalStrave(speed * Time.deltaTime);
        }

    }

    void VerticalStrave(float unit){
            body.AddForce(new Vector2(0, unit * vInput));
    }

    void HorizontalStrave(float unit) {

        body.AddForce(new Vector2(unit * hInput, 0));
    }
}
