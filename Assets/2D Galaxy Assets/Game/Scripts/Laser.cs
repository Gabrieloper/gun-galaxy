using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    [SerializeField]
    private float _speed = 10.0f;

    void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        
        if(transform.position.y >= 5.6f)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Enemy")
         {
            Enemy Enemy = collider.GetComponent<Enemy>();
            Enemy.TakeDamage();
            Destroy(this.gameObject);
        }
    }
}
