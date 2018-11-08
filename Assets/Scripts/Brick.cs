using UnityEngine;

public abstract class Brick : MonoBehaviour {

    public delegate void BrickDestroyed();
    public static event BrickDestroyed OnBrickDestroyed;

    private void OnCollisionEnter(Collision collision) {
        CollisionActions(collision.gameObject);
    }

    private void OnParticleCollision(GameObject other) {
        CollisionActions(other, true);
    }

    protected void NotifyBrickDestroyed(){
        if (OnBrickDestroyed != null) {
            OnBrickDestroyed();
        }
    }

    public abstract void CollisionActions(GameObject collision, bool particleCollision = false);
}
