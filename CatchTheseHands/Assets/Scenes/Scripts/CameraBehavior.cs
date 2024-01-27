using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float offset = 0f;
    public float offsetSmoothing = 0.125f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 desiredPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, offsetSmoothing);
        transform.position = smoothedPosition;
    }
}
