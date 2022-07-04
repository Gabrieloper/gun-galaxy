using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy;
    [SerializeField]
    private GameObject[] Powerups;

    private void Start() {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerupSpawnRoutine());
    }

    private IEnumerator EnemySpawnRoutine()
    {
        while(true)
        {
            Instantiate(Enemy, new Vector2(Random.Range(-8f, 8f), 7), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }

    private IEnumerator PowerupSpawnRoutine()
    {
        while(true) {
            int powerup = Random.Range(0, 3);
            Instantiate(Powerups[powerup], new Vector2(Random.Range(-8f, 8f), 7), Quaternion.identity);
            yield return new WaitForSeconds(10f);
        }
    }
}
