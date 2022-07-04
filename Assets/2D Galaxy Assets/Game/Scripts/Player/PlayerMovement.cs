using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _speed = 7.0f;
    private float _baseSpeed = 7.0f;
    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    public float BaseSpeed
    {
        get => _baseSpeed;
    }

    public void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);

        if (transform.position.x > 7.93f)
        {
            transform.position = new Vector3(7.93f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -7.93f)
        {
            transform.position = new Vector3(-7.93f, transform.position.y, transform.position.z);
        }
        if (transform.position.y > 3.79f)
        {
            transform.position = new Vector3(transform.position.x, 3.79f, transform.position.z);
        }
        else if (transform.position.y < -3.79f)
        {
            transform.position = new Vector3(transform.position.x, -3.79f, transform.position.z);
        }
    }
}
