using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : Enemy
{
    public SceneFade sceneFade;

    public Rigidbody2D rb;

    public float speed = 1f;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        
    }

    protected override void Update()
    {
        //move sparratically
        if (Random.Range(0, 100) < 5)
        {
            rb.velocity = new Vector2(Random.Range(-2, 3) * speed, Random.Range(-2, 3) * speed);
        }
    }

    protected override void Die(){
        sceneFade.nextScene = 2;
        sceneFade.exitScene = true;
        base.Die();
    }
}
