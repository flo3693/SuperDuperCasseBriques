using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Brick : MonoBehaviour {

    [SerializeField] GameObject explosionPrefab;

    private void OnCollisionEnter(Collision collision) {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity, transform.parent);
        CameraShaker.Instance.ShakeOnce(4, 4, 0.1f, 1f);
        Destroy(gameObject);
    }
}
