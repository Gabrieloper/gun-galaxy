using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    [SerializeField]
    public float _speed = 10.0f;
    public static bool hasRicochetPowerUp = false;
    private Rigidbody2D _rigidBody;


    private void Awake() {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _rigidBody.AddForce(new Vector3(9.8f * 25f, 9.8f * 100f, 0));
    }

    void Update()
    {
        
        if(!hasRicochetPowerUp && transform.position.y >= 5.6f)
        {
            Destroy(this.gameObject);
        }
    }
}
