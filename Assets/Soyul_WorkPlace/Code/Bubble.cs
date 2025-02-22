using UnityEngine;

public class Bubble : Projectile
{
    private Rigidbody2D rb;

    private float speed;

    private void Awake()
    {
        // Projectile class
        faction = "Player";
        damage = 1;

        // my class
        rb = GetComponent<Rigidbody2D>();

        speed = 10f;
    }

    private void Start()
    {
        rb.linearVelocity = new Vector2(speed, 0);
    }
}