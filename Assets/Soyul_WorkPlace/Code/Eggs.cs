using UnityEngine;

public class Eggs : Enemy
{
    private Rigidbody2D rb;

    private float speed;

    protected override void Awake()
    {
        // Enemy class
        base.Awake();

        // my class
        rb = GetComponent<Rigidbody2D>();

        speed = -7f;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        max_health = (int)Mathf.Log(GameManager.INSTANCE.GetDifficulty(), 4) ;
        if(max_health < 1) max_health = 1;
        health = max_health;
        
        textUI.text = health.ToString();
        rb.linearVelocity = new Vector2(speed, 0f);
    }

    public override void TakeDamage(float damage) {
        NalchiGang.INSTANCE.AddNalchies((int)damage);
        base.TakeDamage(damage);
    }
}
