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
            Player player = collider.GetComponent<Player>();
            if(player != null) 
            {
                if(this.tag == "Triple") 
                {
                    player.powerUpState.StartTripleShot();
                } else if (this.tag == "Speed") 
                {
                    player.powerUpState.StartSpeedBoost();
                } else if (this.tag == "Shield") 
                {
                    player.powerUpState.StartShieldPowerUp();
                }
            }
            Destroy(this.gameObject);
        }
    }
}
