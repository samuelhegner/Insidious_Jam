using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour {


    public float offSet = 90;
	// Update is called once per frame
	void Update () {
        Vector3 toVector = transform.parent.GetComponent<Rigidbody2D>().velocity.normalized;
        float angle = Mathf.Atan2(toVector.y, toVector.x) * Mathf.Rad2Deg;
        Quaternion NewRot = Quaternion.AngleAxis(angle + offSet, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, NewRot, Time.deltaTime * 1.5f);
    }
}
