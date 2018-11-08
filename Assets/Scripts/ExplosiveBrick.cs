using System.Collections;
using EZCameraShake;
using UnityEngine;
using DG.Tweening;

public class ExplosiveBrick : Brick {

    [SerializeField] GameObject explosion;
    [SerializeField] AudioClip fuseClip;
    [SerializeField] AudioClip explosionClip;
    [SerializeField] Animator bombAnimator;
    [SerializeField] Collider collider;
    [SerializeField] MeshRenderer meshRenderer;

    private void Start() {
        bombAnimator.enabled = false;
    }

    public override void CollisionActions(GameObject collision, bool particleCollision) {
        SoundManager.instance.PlaySingle(fuseClip);
        collider.enabled = false;
        bombAnimator.enabled = true;
        StartCoroutine(launchExplosion());
        NotifyBrickDestroyed();
    }

    IEnumerator launchExplosion() {
        yield return new WaitForSeconds(0.5f);
        bombAnimator.gameObject.SetActive(false);
        meshRenderer.enabled = false;
        explosion.SetActive(true);
        CameraShaker.Instance.ShakeOnce(1, 1, 0.1f, 1f);
        SoundManager.instance.PlaySingle(explosionClip);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
