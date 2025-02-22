using System;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class Ambient : MonoBehaviour
{
    public IObjectPool<GameObject> Pool { get; set; }
    
    private Rigidbody2D rb;

    private float speed;
    private float size;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        speed = Random.Range(-10f, -2.5f);
        size = Random.Range(1f, 2f);
        transform.localScale = new Vector2(size, size);
    }

    private void Update()
    {
        if(transform.position.x < -13f) Pool.Release(gameObject);
    }

    private void OnEnable()
    {
        rb.linearVelocity = new Vector2(speed, 0f);
    }
}