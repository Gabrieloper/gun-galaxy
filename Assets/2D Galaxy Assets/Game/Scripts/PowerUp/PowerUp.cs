using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _powerUpSpeed = 3.0f;

    void Update()
    {
        transform.Translate(Vector3.down * _powerUpSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player") 
        {
            Player Player = collider.GetComponent<Player>();
            if(Player != null) 
            {
                if(this.tag == "Triple") 
                {
                    Player.PowerUpState.StartTripleShot();
                } else if (this.tag == "Speed") 
                {
                    Player.PowerUpState.StartSpeedBoost();
                } else if (this.tag == "Shield") 
                {
                    Player.PowerUpState.StartShieldPowerUp();
                }
            }
            Destroy(this.gameObject);
        }
    }
}
