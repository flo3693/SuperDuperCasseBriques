using UnityEngine;

public class NormalBrick : Brick {
    [SerializeField] AudioClip collisionSound;
    
    public override void CollisionActions(GameObject collision, bool particleCollision) {
        if(!particleCollision)
            SoundManager.instance.PlaySingle(collisionSound);
        NotifyBrickDestroyed();

        Destroy(gameObject);
    }
}
