using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPositioner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 NewPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		transform.position = NewPosition;



	}
}
