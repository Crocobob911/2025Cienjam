using UnityEngine;

public class Bubble : Projectile
{
    private Rigidbody2D rb;

    private float speed = 25f;

    private void Awake() {
        faction = "Player";
        damage = 1;
    }
    
    private void Update() {
        if (transform.position.x > 15f) {
            Die_override();
        }
        
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    protected override void Die_override() {
        BubbleProjectilePoolManager.INSTANCE.Pool.Release(gameObject);
    }
}