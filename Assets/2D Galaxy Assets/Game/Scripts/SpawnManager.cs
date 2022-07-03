using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy;
    [SerializeField]
    private GameObject[] Powerups;

    private float spawnTimer = 5.0f;
    private float deltaTime = 0.0f;

    //TODO: Avoid spawning new enemies in the same horizontal position as old enemies
    void Update()
    {
        deltaTime += Time.deltaTime;
        if(deltaTime >= spawnTimer)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(Enemy, new Vector2(Random.Range(-8-0f, 8.0f), 6.8f), Quaternion.identity);
        deltaTime = 0;
    }

    private void SetSpawnTimer()
    {
        spawnTimer = Random.Range(2.0f, 5.0f);
    }
}
