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
        max_health = Mathf.Log(GameManager.INSTANCE.GetDifficulty(), 10) ;
        if(max_health < 1) max_health = 1;
        rb.linearVelocity = new Vector2(speed, 0f);
    }

    public override void TakeDamage(float damage) {
        base.TakeDamage(damage);
        NalchiGang.INSTANCE.AddNalchies((int)damage);
    }
}
