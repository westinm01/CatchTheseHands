using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MovingEnemy
{
    public Sprite deathSprite;
    // Start is called before the first frame update
    /*override void Start()
    {
        
    }*/

    // Update is called once per frame
    protected override void Update()
    {
        if(health > 0){
            base.Update();
        }
    }

    protected override void Die(){
        //disable animation component
        //disable rigidbody
        //disable collider
        //change spriterender sprite to chicken
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = deathSprite;
    }
}
