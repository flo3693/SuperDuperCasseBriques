using UnityEngine;
using System.Collections;

public class Eye : MonoBehaviour {
    GameObject _paddle;

    void Start() {
        _paddle = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        if (_paddle != null) {
            transform.LookAt(_paddle.transform);
        } else {
            Start();
        }
    }
}
