using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _health = 1;
    [SerializeField]
    private GameObject _enemyExplosion;

    public void TakeDamage()
    {
        _health -= 1;
        if(_health == 0) {
            DeathAnimation();
            Destroy(this.gameObject);
        }
    }

    public void DeathAnimation()
    {
        // TODO: Destroy enemy explosion prefab when animation ends
        Instantiate(_enemyExplosion, transform.position, Quaternion.identity);
    }
}
