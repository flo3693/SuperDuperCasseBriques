using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Brick : MonoBehaviour {

    [SerializeField] GameObject explosionPrefab;
    [SerializeField] AudioClip explosionClip;

    private void OnCollisionEnter(Collision collision) {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity, transform.parent);
        CameraShaker.Instance.ShakeOnce(1, 1, 0.1f, 1f);
        SoundManager.instance.PlaySingle(explosionClip);
        Destroy(gameObject);
    }
}
