using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public SceneFade loadFade;

    public int nextScene = 1;
    // Start is called before the first frame update
    void Start()
    {
        //loadFade = GameObject.Find("Load").GetComponent<SceneFade>();
    }

    // Update is called once per frame
    void Update()
    {
        //get second child and enable/disable it every 1 second
        transform.GetChild(1).gameObject.SetActive((int)(Time.time * 2) % 2 == 0);
        //check if the user inputs any key
        if(Input.anyKeyDown){
            //load the first level
            loadFade.nextScene = nextScene;
            loadFade.exitScene = true;
            
        }
    }
}
