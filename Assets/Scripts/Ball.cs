using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour {
    public Rigidbody rb;
    public float speed;

    bool ballFired;
    bool isWaiting;
    bool slowBall;

    void Update() {
        if (Input.GetKey(KeyCode.Space) && !ballFired) {//Lance la balle
            ballFired = true;
            transform.parent = null;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(0, speed * 1000, 0));
            StartCoroutine(wait());
        } else if (Input.GetKey(KeyCode.Space) && ballFired && !isWaiting) {//Débloquer balle bloqué
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector3(0, -speed * 1000, 0));
            StartCoroutine(wait());
        }
    }

    IEnumerator wait() {
        isWaiting = true;
        yield return new WaitForSeconds(1);
        isWaiting = false;
    }

    public void SlowBall() {
        if (!slowBall) {
            slowBall = true;
            rb.velocity /= 2;
            SoundManager.instance.ChangeMusicSpeed(0.85f);
            StartCoroutine(restoreSpeed());
        }
    }

    IEnumerator restoreSpeed() {
        yield return new WaitForSeconds(5);
        rb.velocity *= 2;
        slowBall = false;
        SoundManager.instance.ChangeMusicSpeed(1);
    }
}
