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
            //transform.LookAt(_paddle.transform);
            Vector3 targetDir = _paddle.transform.position - transform.position;
            float rotationZ = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ+90);
            //transform.Rotate(Vector3.forward, angle);
        } else {
            Start();
        }
    }
}
