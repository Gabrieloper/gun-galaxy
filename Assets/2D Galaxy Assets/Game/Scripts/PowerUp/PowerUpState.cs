using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpState : MonoBehaviour
{
    public Dictionary<string, bool> powerUps = new Dictionary<string, bool>();
    [SerializeField] float _speedBoostVelocity = 15.0f;
    Player Player;

    private void Awake()
    {
        powerUps.Add("tripleShot", false);
        powerUps.Add("speed", false);
        powerUps.Add("shield", false);

        Player = GetComponent<Player>();
    }

    public bool getPowerUpState(string powerUp) {
        return powerUps[powerUp];
    }

    public void setPowerUpState(string powerUp, bool powerUpState) {
        powerUps[powerUp] = powerUpState;
    }

    public void StartTripleShot()
    {
        setPowerUpState("tripleShot", true);
        StartCoroutine(TripleShotPowerDownRoutine(5.0f));
    }

    public void StartSpeedBoost()
    {
        setPowerUpState("speed", true);
        Player.PlayerMovement.Speed = _speedBoostVelocity;
        StartCoroutine(SpeedBoostPowerDownRoutine(7.0f));
    }

    public void StartShieldPowerUp()
    {
        setPowerUpState("shield", true);
        Player.Shield.SetActive(true);
    }

    private IEnumerator TripleShotPowerDownRoutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        setPowerUpState("tripleShot", false);
    }

    private IEnumerator SpeedBoostPowerDownRoutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        powerUps["speed"] = false;
        Player.PlayerMovement.Speed = Player.PlayerMovement.BaseSpeed;
    }
}
