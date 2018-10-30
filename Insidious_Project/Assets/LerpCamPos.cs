using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpCamPos : MonoBehaviour {

    GameObject player;

    public float lerpSpeed;

    Vector3 posToMove;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
	}
	

	// Update is called once per frame
	void Update () {
        posToMove = new Vector3(player.transform.position.x, player.transform.position.y, -10f);

        transform.position = Vector3.Lerp(transform.position, posToMove, Time.deltaTime * lerpSpeed);
	}
}
