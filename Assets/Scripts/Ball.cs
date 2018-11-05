using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public Rigidbody rb;
    public float force;

    bool ballFired;
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.Space) && !ballFired){
            ballFired = true;
            transform.parent = null;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(0, force, 0));
        }
	}
}
