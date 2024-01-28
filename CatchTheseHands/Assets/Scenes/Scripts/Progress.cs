using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public float endX = 120;
    public float currX = 0;

    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        currX = player.transform.position.x;
        //move progress bar
        transform.localPosition = new Vector3((currX / endX) * 400 - 200, 0, 0);

    }
}
