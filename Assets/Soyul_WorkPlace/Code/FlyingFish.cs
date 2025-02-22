using UnityEngine;
using System.Collections;

public class FlyingFish : MonoBehaviour
{
    private Rigidbody2D rb;

    private float jumpForce;

    [SerializeField] private GameObject bubble;
    [SerializeField] private GameObject effect_particle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        jumpForce = 1000;
    }

    private void Start()
    {
        StartCoroutine(ShootBubble());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Die();
        }
    }

    IEnumerator ShootBubble()
    {
        while (true)
        {
            Attack(bubble);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void Attack(GameObject projectile)
    {
        GameObject temp = Instantiate(projectile);
        temp.transform.position = transform.position;
    }

    private void Die()
    {
        GenerateEffect();
        Destroy(gameObject);
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