using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBounce : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D _rigidBody;
    private Vector3 previousVelocity;


    private void Awake() {
        _rigidBody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        previousVelocity = _rigidBody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collider) {
        if(collider.transform.tag == "Wall") {
            var speed = previousVelocity.magnitude;
            var direction = Vector3.Reflect(previousVelocity.normalized, collider.contacts[0].normal);

            _rigidBody.velocity = direction * Mathf.Max(speed, 0f);
        }
    }
}
