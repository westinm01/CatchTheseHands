using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : JumpingEnemy
{

    public List<Sprite> deathSprites = new List<Sprite>();
    protected override void Die(){
        spriteRenderer.sprite = deathSprites[Random.Range(0, deathSprites.Count)];
        
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        gameObject.GetComponent<Collider2D>().enabled = false;

    }
}
