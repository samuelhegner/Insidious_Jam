using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float runSpeed;
    public float patrolSpeed;

    List<GameObject>waypoints = new List<GameObject>();

    Rigidbody2D rb;

    GameObject player;

    int waypoint;

    public enum EnemyState{
        patrol,
        idle, 
        flee
    }

    public EnemyState currentState;

     void Awake()
    {
        for (int i = 0; i < transform.childCount; i++){
            GameObject child = transform.GetChild(i).gameObject;
            waypoints.Add(child);
        }

        foreach(GameObject gm in waypoints){
            gm.transform.parent = null;
        }
    }

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

            if (GAME_MANAGER.GM.Raged == false)
            {
                currentState = EnemyState.patrol;
                waypoint = GetNearestWaypoint(transform.position);
            }

        }
        else if(currentState == EnemyState.flee){
            Vector2 fleedDir = (transform.position - player.transform.position);
            fleedDir.Normalize();

            rb.velocity = fleedDir * runSpeed;

            if (Vector2.Distance(transform.position, player.transform.position) > 5f)
            {
                currentState = EnemyState.idle;
            }

            if (GAME_MANAGER.GM.Raged == false){
                currentState = EnemyState.patrol;
                waypoint = GetNearestWaypoint(transform.position);
            }


        }
        else if(currentState == EnemyState.patrol){
            Vector2 toWaypoint = waypoints[waypoint].transform.position - transform.position;
            toWaypoint.Normalize();
            rb.velocity = toWaypoint * patrolSpeed;
            if (Vector2.Distance(transform.position, waypoints[waypoint].transform.position) < 1){
                waypoint = (waypoint + 1) % waypoints.Count;
            }
        }
	}

    int GetNearestWaypoint(Vector2 currentPos){

        int index = 0;

        float closestDist = float.MaxValue;

        for (int i = 0; i < waypoints.Count; i++){
            if(Vector2.Distance(currentPos, waypoints[i].transform.position) < closestDist){
                index = i;
            }
        }

        return index;
    }
}
