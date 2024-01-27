using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToDelete : MonoBehaviour
{
    SpriteRenderer sr;
    public float fadeSpeed = 0.1f;
    public float fadeTime = 0.5f;
    private float fadeTimer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeTimer > fadeTime){
            Destroy(gameObject);
        }
        else{
            fadeTimer += Time.deltaTime;
            //sr.color interpolates alpha between one and zero
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, Mathf.Lerp(1, 0 , fadeTimer/fadeTime));

        }

    }
}
