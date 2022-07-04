using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    Player Player;

    private void Awake() 
    {
        Player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Enemy")
        {
            Enemy Enemy = collider.GetComponent<Enemy>();
            Enemy.TakeDamage();
            Player.TakeDamage(1);
        }
    }
}
