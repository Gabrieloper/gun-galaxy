using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private float _speed = 5.0f;
    private float _endPosition = 8.08f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
        if(transform.position.y <= -6.13f) {
            transform.position = new Vector2(Random.Range(-_endPosition, _endPosition), _endPosition);
        }
    }
}