using UnityEngine;

public class Particle : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        float size = Random.Range(1f, 2f);
        transform.localScale = new Vector2(size, size);
        rb.linearVelocity = new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-7.5f, 7.5f));
        transform.right = rb.linearVelocity;
    }

    private void FixedUpdate()
    {
        transform.localScale *= 0.9f;
        rb.linearVelocity *= 0.9f;
        if (Vector2.SqrMagnitude(transform.localScale) < 0.1f || Vector2.SqrMagnitude(rb.linearVelocity) < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}