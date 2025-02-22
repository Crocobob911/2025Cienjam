using System;
using UnityEngine;
using UnityEngine.Pool;

public class BubbleProjectile : MonoBehaviour
{
    public IObjectPool<GameObject> Pool { get; set; }

    [SerializeField] private float speed;

    private void Update() {
        if (transform.position.x > 15f) {
            Pool.Release(gameObject);
        }
        
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
