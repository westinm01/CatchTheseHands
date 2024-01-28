using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<Vector3> spawnPoints = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Vector3 spawnPoint in spawnPoints){
            Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
        }
    }
}
