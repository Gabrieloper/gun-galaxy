using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerExplosion;
    [SerializeField]
    public GameObject shield;
    [SerializeField]
    internal PlayerAttack playerAttack;
    [SerializeField]
    internal PowerUpState powerUpState;
    [SerializeField]
    internal PlayerMovement playerMovement;
    [SerializeField]
    private int _health = 1;

    void Start()
    {
       transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        playerMovement.Move();
        playerAttack.Attack();
    }

    private void DeathAnimation()
    {
        Instantiate(_playerExplosion, transform.position, Quaternion.identity);
    }

    // create general function that is decoupled of any component and provides the same functionality for it to be reutilized
    public void TakeDamage(int damage)
    {
        if(!powerUpState.getPowerUpState("shield"))
        {
            this._health -= damage;
        } else
        {
            powerUpState.setPowerUpState("shield", false);
            shield.SetActive(false);
            return;
        }
        if(this._health == 0)
        {
            DeathAnimation();
            Destroy(this.gameObject);
        }
    }

}
