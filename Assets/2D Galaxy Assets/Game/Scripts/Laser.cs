using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    [SerializeField]
    private float speed = 10.0f;

    void Start()
    {
        Debug.Log(transform.position.y);
    }


    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        
        if(transform.position.y >= 5.6f)
        {
            Destroy(this.gameObject);
        }
    }
}
