using UnityEngine;

public class Ambient : MonoBehaviour
{
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

    private void Start()
    {
        rb.linearVelocity = new Vector2(speed, 0f);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}