﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {

    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 10.0f;
    float startTime;


    SpriteRenderer sprite;

    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        float t = (Time.time - startTime) / duration;
        sprite.color = new Color(1f, 1f, 1f, Mathf.Lerp(maximum, minimum, t));

        if(sprite.color.a <= 0.01){
            Destroy(gameObject);
        }
    }


}
