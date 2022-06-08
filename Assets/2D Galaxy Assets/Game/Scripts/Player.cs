using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject laserPrefab;

    [SerializeField]
    private float speed = 7.0f;

    void Start()
    {
       transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);

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

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(
                laserPrefab,
                new Vector3(
                    transform.position.x,
                    transform.position.y + 0.9f,
                    transform.position.z
                ),
                Quaternion.identity
            );
        }
    }
}
