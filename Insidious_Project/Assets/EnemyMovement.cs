using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float runSpeed;

    Rigidbody2D rb;

    GameObject player;

    public enum EnemyState{
        patrol,
        idle, 
        flee
    }

    public EnemyState currentState;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        currentState = EnemyState.flee;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(currentState == EnemyState.idle){
            rb.velocity = Vector2.zero;

            if(Vector2.Distance(transform.position, player.transform.position) < 5f){
                currentState = EnemyState.flee;
            }

        }else if(currentState == EnemyState.flee){
            Vector2 fleedDir = (transform.position - player.transform.position);
            fleedDir.Normalize();

            rb.velocity = fleedDir * runSpeed;

            if (Vector2.Distance(transform.position, player.transform.position) > 5f)
            {
                currentState = EnemyState.idle;
            }
        }
	}
}
