using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    [SerializeField] GameObject _laserPrefab;
    [SerializeField] GameObject _tripleShotPrefab;
    private float _canFire = 0.0f;
    private float _fireRate = 0.25f;
    [SerializeField] PowerUpState PowerUpState;

    private void Awake() 
    {
        PowerUpState = GetComponent<PowerUpState>();
    }


    private void SpawnFrontalLaser(float frontalValue) 
    {
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

    private void SpawnTripleShot() 
    {
        Instantiate(
            _tripleShotPrefab,
            transform.position,
            Quaternion.identity
        );
    }

    public void Attack()
    {
        if (hasFired() && Time.time > _canFire)
        {

            if(PowerUpState.getPowerUpState("tripleShot"))
            {
                SpawnTripleShot();
            } else {
                SpawnFrontalLaser(0.9f);
            }
            _canFire = Time.time + _fireRate;
        }
    }

    private bool hasFired()
    {
        return Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0);
    }
}
