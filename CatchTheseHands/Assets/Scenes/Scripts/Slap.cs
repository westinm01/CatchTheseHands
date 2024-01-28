using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Slap : MonoBehaviour
{
    // Start is called before the first frame update

    public int damage = 50;
    public float slapTime = 0.5f;
    private float slapTimer = 0;

    public Vector2 initialPosition;
    public Vector2 finalPosition;

    public int numPoints = 3;
    private List<Vector2> points = new List<Vector2>();

    public AudioClip slapSound;

    public AudioClip killSound;

    void Start()
    {
        points.Add(initialPosition);
        for (int i = 2; i < numPoints; i++){
            points.Add(CreateMidVector(initialPosition, finalPosition));
        }
        points.Add(finalPosition);
    }

    Vector2 CreateMidVector(Vector2 a, Vector2 b){
        if(a.x > b.x){
            return new Vector2((a.x + b.x)/2 + .5f, (a.y + b.y)/2 - 1); //custom func
        }
        return new Vector2((a.x + b.x)/2 - .5f, (a.y + b.y)/2 - 1); //custom func
    }

    Vector2 GetPoint(List<Vector2> points, int start, int end, float t){
        if(end == start){
            return points[start];
        }
        if(end - start == 1){
            return new Vector2((1 - t)* points[start].x + t*points[end].x, (1 - t)*points[start].y + t*points[end].y);
        }
        Vector2 p1 = GetPoint(points, start, end / 2, t);
        Vector2 p2 = GetPoint(points, end/2, end, t);
        return new Vector2((1 - t)* p1.x + t*p2.x, (1 - t)*p1.y + t*p2.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(slapTimer > slapTime){
            Destroy(gameObject, 0.3f);
        }
        else{
            transform.localPosition = GetPoint(points, 0, points.Count - 1, slapTimer/slapTime);
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -1);
            slapTimer += Time.deltaTime;

        }
    }
}
