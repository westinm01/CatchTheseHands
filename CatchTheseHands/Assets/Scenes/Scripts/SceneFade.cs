using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour
{
    public float fadeSpeed = 1f;

    private float t = 0f;

    public int nextScene = 0;

    private Color nextColor = new Color(0, 0, 0, 0);

    Image i;

    private Color currentColor;

    public bool exitScene = false;
    // Start is called before the first frame update
    void Start()
    {
        i = gameObject.GetComponent<Image>();
        currentColor = i.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(t < fadeSpeed){
            t += Time.deltaTime;
            InterpolateColor(currentColor, nextColor, t/fadeSpeed);
            if(t >= fadeSpeed){
                currentColor = nextColor;
                if(exitScene){
                    SceneManager.LoadScene(nextScene);
                }
            }
        }
        else if(exitScene){
            t = 0f;
            nextColor = new Color(0f, 0f, 0f, 1f);
        }

    }

    public void InterpolateColor(Color color1, Color color2, float t){
        
        i.color = new Color(color1.r + (color2.r - color1.r) * t, color1.g + (color2.g - color1.g) * t, color1.b + (color2.b - color1.b) * t, color1.a + (color2.a - color1.a) * t);
    }
}
