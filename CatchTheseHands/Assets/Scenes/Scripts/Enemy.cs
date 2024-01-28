using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject worldCanvas;
    private int health;
    public int initialHealth = 100;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        health = initialHealth;
        //find worldcanvas by tag
        audio = GetComponent<AudioSource>();
        worldCanvas = GameObject.FindGameObjectsWithTag("WorldCanvas")[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Slap"){
            int damage = other.gameObject.GetComponent<Slap>().damage;
            int criticalHit = Random.Range(0,100);
            bool isCritical = criticalHit < 10;
            int lowBound = (int)(damage * 0.9);
            int highBound = (int)(damage * 1.1);  
            damage = Random.Range(lowBound, highBound);
            damage = isCritical ? damage * 2 : damage;
            health -= damage;
            
            if(health <= 0){
                health = 0;
                audio.clip = other.gameObject.GetComponent<Slap>().killSound;
                audio.Play();
            }
            else{
                audio.clip = other.gameObject.GetComponent<Slap>().slapSound;
                audio.Play();
            }
            transform.GetChild(0).localScale = new Vector3(((float)health)/((float)initialHealth), .1f, 1);
            if(health <= 0){
                Die();
            }
        }
    }

    void Die(){
        //maybe some type of animation or particle effect
        //get rigid body and add an upward force
        //destroy game object
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        //disable collider
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 5f);
    }
}
