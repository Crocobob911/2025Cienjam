using System;
using UnityEngine;

public class Tuna : Enemy
{
    private Rigidbody2D rb;

    private float speed;

    protected override void Awake()
    {
        // Enemy class
        base.Awake();

        // my class
        rb = GetComponent<Rigidbody2D>();

        speed = -5f;
    }

    private void OnEnable()
    {
        rb.linearVelocity = new Vector2(speed, 0f);
    }

    //private void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}
}