using UnityEngine;

public class Deadzone : MonoBehaviour {
    
    public delegate void BallDead();
    public static event BallDead OnBallDead;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Ball"){
            Destroy(other.gameObject);
            if (OnBallDead != null)
                OnBallDead();
        }
    }
}
