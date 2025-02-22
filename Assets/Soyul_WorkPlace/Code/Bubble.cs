using UnityEngine;
using UnityEngine.Pool;

public class Bubble : MonoBehaviour {
    private string faction;
    public void SetFraction(string value) { faction = value; }

    private int damage;
    
    [SerializeField] private GameObject effect_particle;
    
    private Rigidbody2D rb;
    public IObjectPool<GameObject> Pool { get; set; }

    private float speed = 25f;

    private void Start() {
        faction = "Player";
        damage = 1;
    }
    
    private void Update() {
        if (transform.position.x > 15f) {
            Pool.Release(gameObject);
        }
        
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Border")) Pool.Release(gameObject);
        else if (other.CompareTag("Enemy")) {
            var oec = other.GetComponent<Enemy>();
            if (oec != null)
            {
                oec.TakeDamage(damage);
                Die();
            }
        }
    }
    
    private void Die() {
        GenerateEffect();
        Pool.Release(gameObject);
    }
    
    private void GenerateEffect() {
        for (int i = 0; i < 15; i++)
        {
            GameObject temp = Instantiate(effect_particle);
            temp.transform.position = transform.position;
        }
    }
}