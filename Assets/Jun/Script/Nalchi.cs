using System;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class Nalchi : MonoBehaviour {
    
    public IObjectPool<GameObject> Pool { get; set; }
    
    [SerializeField] private GameObject gangCenter;
    [SerializeField] private Rigidbody2D rb;

    private float shootCoolTime = 0f;
    
    private void Awake() {
        gangCenter = gameObject.transform.parent.gameObject;
    }

    private void OnEnable() {
        SetRandomPositionOnEnable();
    }
    
    private void Update() {
        ShootBubble();
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
        if (shootCoolTime >= 0.4f) {
            shootCoolTime = 0f;
            var bubble = BubbleProjectilePoolManager.INSTANCE.Pool.Get();
            bubble.transform.position = transform.position;
        }
        shootCoolTime += Time.deltaTime;
    }
}
