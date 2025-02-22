using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour
{
    protected string faction; public string GetFaction() { return faction; }
    protected float health;
    protected float max_health;
    
    public IObjectPool<GameObject> Pool { get; set; }

    [SerializeField] private GameObject[] effect_particles;

    protected virtual void Awake()
    {
        faction = "Enemy";
        gameObject.tag = "Enemy";
    }

    protected virtual void Start()
    {
        InitStat();
    }

    private void InitStat()
    {
        health = max_health;
    }

    public void TakeDamage(float damage)
    {
        if (health - damage > 0)
        {
            health -= damage;
            GenerateEffect("Hit"); // enum?
            //DisplayNumber(damage);
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        health = 0;
        ScoreManager.INSTANCE.AddScore(5);
        GenerateEffect("Die"); // enum?
        Pool.Release(gameObject);
    }

    private void DisplayNumber(float number)
    {
        // ...
    }

    private void GenerateEffect(string effect_type)
    {
        if (effect_type == "Hit")
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject temp = Instantiate(effect_particles[0]);
                if (temp == null) { return; }
                temp.transform.position = transform.position;
            }
        }
        else if (effect_type == "Die")
        {
            for (int i = 0; i < 30; i++)
            {
                GameObject temp = Instantiate(effect_particles[1]);
                if (temp == null) { return; }
                temp.transform.position = transform.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Border"))
        {
            Pool.Release(gameObject);
        }
    }
}
