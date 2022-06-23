using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject[] powerups;

    private float initialSpawnTimer = 7.0f;
    private float deltaTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //TODO: Avoid spawning new enemies in the same horizontal position as old enemies
    void Update() {
        deltaTime += Time.deltaTime;
        if(deltaTime >= initialSpawnTimer) {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy() {
        Instantiate(enemy, new Vector2(Random.Range(-8-0f, 8.0f), 6.8f), Quaternion.identity);
        deltaTime = 0;
    }

    private void SetSpawnTimer() {
        initialSpawnTimer = Random.Range(5.0f, 10.0f);
    }
}
