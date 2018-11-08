using UnityEngine;

public class SlowBrick : Brick {
    [SerializeField] AudioClip collisionSound;

    public override void CollisionActions(GameObject collision, bool particleCollision) {
        var ball = GameObject.FindWithTag("Ball");
        if (ball != null) {
            ball.GetComponent<Ball>().SlowBall();
        }
        if (!particleCollision)
            SoundManager.instance.PlaySingle(collisionSound);
        NotifyBrickDestroyed();

        Destroy(gameObject);
    }
}
