using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : Enemy
{


    public float speed = 6f;

    protected float runSpeed;
    public float distance = 4f;
    private float slowTimer = 0f;

    

    public Vector2 initialPosition;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        initialPosition = transform.localPosition;
        runSpeed = speed;

    }

    // Update is called once per frame
    protected override void Update()
    {


        base.Update();
        if(slowTimer > 0){
            slowTimer -= Time.deltaTime;
        }
        else{
            runSpeed = speed;
        }
        //transform.localPosition = new Vector2(initialPosition.x + Mathf.PingPong(Time.time * runSpeed, distance), initialPosition.y);
        //apply a force to the rigidbody to move it back and forth
        float xDir = Mathf.PingPong(Time.time * speed, distance) - distance/2;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xDir, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        if(xDir > 0){
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else{
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        
    }

    protected override void OnTriggerEnter2D(Collider2D other){
        
        if(other.gameObject.tag == "Slap"){
            runSpeed = .2f;
            slowTimer = 3f;
        }
        base.OnTriggerEnter2D(other);
    }
}
