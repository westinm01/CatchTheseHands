using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5f;
    public float jumpForce = 5f;

    public float hopForce = 1f;
    Rigidbody2D rb;

    Animator anim;

    public int jumpState = 0; // 0 = grounded, 1 = 1 jump, 2 = 2 jumps.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
        if (x == -1){
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (x == 1){
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if ((x == -1 || x == 1) && jumpState == 0){
            rb.velocity = new Vector2(rb.velocity.x, hopForce);
            jumpState++;
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpState < 3)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpState++;
        }

        anim.SetInteger("MoveState", jumpState);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpState = 0;
        }
    }
}
