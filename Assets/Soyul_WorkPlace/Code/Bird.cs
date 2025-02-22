using UnityEngine;

public class Bird : Enemy
{
    private Rigidbody2D rb;

    private float speed;

    protected override void Awake()
    {
        // Enemy class
        base.Awake();
        max_health = 10;

        // my class
        rb = GetComponent<Rigidbody2D>();

        speed = -10f;
    }

    protected override void Start()
    {
        // Enemy class
        base.Start();

        // my class
        rb.linearVelocity = new Vector2(speed, 0f);
    }

    //private void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}
}