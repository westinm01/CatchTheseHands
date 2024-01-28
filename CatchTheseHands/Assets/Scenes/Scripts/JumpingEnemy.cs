using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : Enemy
{
    public float jumpForce = 10f;
    public float horizontalForce = 5f;
    public float jumpCooldown = 6f;
    private float jumpTimer = 0f;

    float direction = 1f;

    protected SpriteRenderer spriteRenderer;
    public List<Sprite> sprites = new List<Sprite>();

    // Start is called before the first frame update
    protected override void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[0];
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
            if(health > 0){
                if(jumpTimer > 0){
                    jumpTimer -= Time.deltaTime;
                }
                else{
                    jumpTimer = jumpCooldown;
                    Jump();
                }
                if(gameObject.GetComponent<Rigidbody2D>().velocity.y < 0){
                    //rotate sprite to the left by 90 degrees
                    //transform.rotation = Quaternion.Euler(0, 0, -90);
                }
            }

    }

    void Jump(){
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalForce * direction, jumpForce), ForceMode2D.Impulse);

        spriteRenderer.sprite = sprites[1];
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Ground"){
            direction *= -1f;
            spriteRenderer.sprite = sprites[0];
            transform.rotation = Quaternion.Euler(0, 0, 0);
            spriteRenderer.flipX = direction < 0;
        }
    }

}
