using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected string faction; public void SetFaction(string value) { faction = value; }
    protected float damage;

    [SerializeField] private GameObject effect_particle;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Border")
        {
            Die();
        }
        else if (other.tag == "Enemy")
        {
            Enemy oec = other.GetComponent<Enemy>(); // other enemy component
            if (oec != null) { oec.TakeDamage(damage); }
        }
        else
        {
            return;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
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