using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public float speed = 1;
	// Update is called once per frame
	void Update () {
        var posX = transform.position.x + (Input.GetAxis("Horizontal") * speed);
        transform.position = Vector3.right * Mathf.Clamp(posX,-8,8);
	}
}
