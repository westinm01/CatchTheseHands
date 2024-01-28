using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject Heart;
    public GameObject HeartsGroup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth(int numHearts){
        int healthCount = HeartsGroup.transform.childCount;
        for (int i = 0; i < healthCount; i++){
            Destroy(HeartsGroup.transform.GetChild(i).gameObject);
        }
        for(int i = 0; i < numHearts; i++){
            GameObject heart = Instantiate(Heart, new Vector3(0, 0, 0), Quaternion.identity, HeartsGroup.transform);
        }
    }
}
