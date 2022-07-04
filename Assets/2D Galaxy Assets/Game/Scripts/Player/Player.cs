using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerExplosion;
    [SerializeField]
    public GameObject Shield;
    [SerializeField]
    internal PlayerAttack PlayerAttack;
    [SerializeField]
    internal PowerUpState PowerUpState;
    [SerializeField]
    internal PlayerMovement PlayerMovement;
    [SerializeField]
    private int _health = 3;
    private UIManager UIManager;


    void Start()
    {
       transform.position = new Vector3(0, 0, 0);
    }

    private void Awake() 
    {
        UIManager = GameObject.FindWithTag("Canvas").GetComponent<UIManager>();
    }

    void Update()
    {
        PlayerMovement.Move();
        PlayerAttack.Attack();
    }

    private void DeathAnimation()
    {
        Instantiate(_playerExplosion, transform.position, Quaternion.identity);
    }

    // create general function that is decoupled of any component and provides the same functionality for it to be reutilized
    public void TakeDamage(int damage)
    {
        if(!PowerUpState.getPowerUpState("shield"))
        {
            _health -= damage;
            UIManager.UpdateLives(_health);
        } else
        {
            PowerUpState.setPowerUpState("shield", false);
            Shield.SetActive(false);
            return;
        }
        if(_health == 0)
        {
            // TODO: Destroy player explosion prefab when animation ends
            DeathAnimation();
            Destroy(gameObject);
        }
    }

}
