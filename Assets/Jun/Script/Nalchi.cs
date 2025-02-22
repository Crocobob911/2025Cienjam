using System;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class Nalchi : MonoBehaviour {
    
    public IObjectPool<GameObject> Pool { get; set; }
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject effect_particle;

    private float shootCoolTime = 0f;

    private void OnEnable() {
        SetRandomPositionOnEnable();
    }
    
    private void Update() {
        ShootBubble();
    }
    
    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.CompareTag("Enemy"))
        {
            Die();
        }
    }

    public void GatherToCenter() {
        var dir = -transform.localPosition;
        rb.AddForce(dir, ForceMode2D.Impulse);
    }

    private void SetRandomPositionOnEnable() {
        var randVec = Random.insideUnitCircle;
        rb.AddForce(randVec);
    }

    public void Jump(float jumpForce) {
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);     
    }

    private void ShootBubble() {
        if (shootCoolTime >= 0.5f) {
            shootCoolTime = 0f;
            var bubble = BubbleProjectilePoolManager.INSTANCE.Pool.Get();
            bubble.transform.position = transform.position;
        }
        shootCoolTime += Time.deltaTime;
    }
    
    private void Die()
    {
        GenerateEffect();
        NalchiPoolManager.INSTANCE.Pool.Release(gameObject);
        NalchiGang.INSTANCE.RemoveNalchi(this);
    }
    
    private void GenerateEffect()
    {
        for (int i = 0; i < 15; i++)
        {
            GameObject temp = Instantiate(effect_particle);
            temp.transform.position = transform.position;
        }
    }
}
