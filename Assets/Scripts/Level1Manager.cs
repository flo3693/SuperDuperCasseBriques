using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour {

    [SerializeField] Transform leftWall;
    [SerializeField] Transform rightWall;
    [SerializeField] Transform topWall;

    void Start() {
        var paddle = Instantiate(Resources.Load<GameObject>("Prefabs/Paddle2"), Vector3.zero, Quaternion.identity);
        paddle.GetComponent<Paddle>().Initialize(rightWall);
    }
}
