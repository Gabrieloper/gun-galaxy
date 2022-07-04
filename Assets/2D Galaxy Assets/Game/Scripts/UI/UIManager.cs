using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _lives;
    [SerializeField]
    private Image _livesDisplay;

    public void UpdateLives(int currentLives) 
    {
        _livesDisplay.sprite = _lives[currentLives];
    }

    public void UpdateScore()
    {

    }
}
