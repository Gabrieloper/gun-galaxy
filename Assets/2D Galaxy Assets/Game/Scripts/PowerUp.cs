using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private GameObject _powerUpPrefab;
    [SerializeField]
    private float _powerUpSpeed = 3.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _powerUpSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Player") {
            Player player = collider.GetComponent<Player>();
            if(this.tag == "Triple") {
                player.StartTripleShot();
            } else if (this.tag == "Speed") {
                player.StartSpeedBoost();
            }
            Destroy(this.gameObject);
        }
    }
}
