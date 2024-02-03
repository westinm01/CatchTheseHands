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

    int health = 3;

    public int jumpState = 0; // 0 = grounded, 1 = 1 jump, 2 = 2 jumps.

    public GameObject jumpCircle;

    private CanvasManager canvasManager;

    public GameObject slapPrefab;

    public AudioClip damageSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canvasManager = GameObject.Find("Canvas").GetComponent<CanvasManager>(); //improve later
        canvasManager.UpdateHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0){
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
            
            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && jumpState < 3)
            {
                if(jumpState == 0){
                    jumpState++;
                }
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpState++;
                if(jumpState == 3){
                    Instantiate(jumpCircle, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), Quaternion.identity);
                }
            }

            anim.SetInteger("MoveState", jumpState);

            if(Input.GetKeyDown(KeyCode.E)){
                PerformSlap();
            }
        }
    }

    void PerformSlap(){
        GameObject slap = Instantiate(slapPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, gameObject.transform);
        //slap.GetComponent<Slap>().initialPosition = new Vector2(transform.position.x, transform.position.y);
        
        if(GetComponent<SpriteRenderer>().flipX){
            slap.GetComponent<SpriteRenderer>().flipX = true;
            Slap slapObject = slap.GetComponent<Slap>();
            slapObject.initialPosition = new Vector2(0.5f, slapObject.initialPosition.y);
            slapObject.finalPosition = new Vector2(-1, slapObject.finalPosition.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpState = 0;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            DecreaseHealth();
            GetComponent<AudioSource>().PlayOneShot(damageSound);
        }
    }

    private void OnTriggerEnter2D   (Collider2D collision)
    {
        if (collision.gameObject.tag == "Abyss")
        {
            SetHealth(0);
        }
    }

    public int GetHealth(){
        if(health < 0){
            health = 0;
        }
        return health;
    }
    public void SetHealth(int newHealth){
        health = newHealth;
        canvasManager.UpdateHealth(health);
    }
    public void DecreaseHealth(){
        health--;
        canvasManager.UpdateHealth(health);
    }
    public void IncreaseHealth(){
        health++;
        canvasManager.UpdateHealth(health);
    }
}
