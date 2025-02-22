using UnityEngine;

public class Tuna : Enemy
{
    private Rigidbody2D rb;

    private float speed;

    protected override void Awake()
    {
        // Enemy class
        base.Awake();
        max_health = 5;

        // my class
        rb = GetComponent<Rigidbody2D>();

        speed = -5f;
    }

    protected override void Start()
    {
        // Enemy class
        base.Start();

        // my class
        rb.linearVelocity = new Vector2(speed, 0f);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}