using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public float speed = 1;

    float _clampX;

    public delegate void BallBounce();
    public static event BallBounce OnBallBounceOnPaddle;

    public void Initialize(Transform rightWall) {
        var ball = Instantiate(Resources.Load<GameObject>("Prefabs/Ball"), transform);
        _clampX = rightWall.position.x - rightWall.GetComponent<Collider>().bounds.extents.x - transform.GetComponent<Collider>().bounds.extents.x;
    }

    void Update() {
        var posX = transform.position.x + (Input.GetAxis("Horizontal") * speed);
        transform.position = Vector3.right * Mathf.Clamp(posX, -_clampX, _clampX);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Ball") {
            if (OnBallBounceOnPaddle != null) {
                OnBallBounceOnPaddle();
            }
        }
    }
}
