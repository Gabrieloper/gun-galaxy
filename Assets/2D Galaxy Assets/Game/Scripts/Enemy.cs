using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _health = 1;

    public void TakeDamage() {
        this._health -= 1;
        if(_health == 0) {
            Destroy(this.gameObject);
        }
    }
}
