using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private GameObject _playerExplosion;
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f;
    [SerializeField]
    private float _speed = 7.0f;
    private float _baseSpeed = 7.0f;
    [SerializeField]
    private float _speedBoostVelocity = 15.0f;
    [SerializeField]
    private bool _hasTripleShot = false;
    private int _health = 1;

    void Start()
    {
       transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        Movement();
        Attack();

    }

    private void Movement()
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

    private void spawnFrontalLaser(float frontalValue) {
        Instantiate(
            _laserPrefab,
            new Vector3(
                transform.position.x,
                transform.position.y + frontalValue,
                transform.position.z
            ),
            Quaternion.identity
        );
    }

    private void Attack()
    {
        if (hasFired() && Time.time > _canFire)
        {

            if(_hasTripleShot)
            {
                Instantiate(
                    _tripleShotPrefab,
                    transform.position,
                    Quaternion.identity
                );
            } else {
                spawnFrontalLaser(0.9f);
            }
            _canFire = Time.time + _fireRate;
        }
    }

    private bool hasFired()
    {
        return Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0);
    }

    public void StartTripleShot()
    {
        _hasTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine(5.0f));
    }

    public void StartSpeedBoost()
    {
        this._speed = _speedBoostVelocity;
        StartCoroutine(SpeedBoostPowerDownRoutine(7.0f));
    }

    private IEnumerator TripleShotPowerDownRoutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _hasTripleShot = false;
    }

    private IEnumerator SpeedBoostPowerDownRoutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        this._speed = _baseSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Enemy") {
            Enemy enemy = collider.GetComponent<Enemy>();
            enemy.TakeDamage();
            enemy.DeathAnimation();
            TakeDamage(1);
        }
    }

    private void DeathAnimation() {
        Instantiate(_playerExplosion, transform.position, Quaternion.identity);
    }

    // create general function that is decoupled of any component and provides the same functionality for it to be reutilized
    private void TakeDamage(int damage) {
        this._health -= damage;
        if(this._health == 0) {
            DeathAnimation();
            Destroy(this.gameObject);
        }
    }

}
