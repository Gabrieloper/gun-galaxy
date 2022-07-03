using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    Player player;

    private void Awake() 
    {
        player = GetComponent<Player>();
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Enemy")
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            enemy.TakeDamage();
            this.player.TakeDamage(1);
        }
    }
}
