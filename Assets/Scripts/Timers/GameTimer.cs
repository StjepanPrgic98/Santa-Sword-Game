using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI gameTimerText;


    int gameTimer = 0;
    private void Start()
    {
        InvokeRepeating(nameof(IncreaseGameTimer), 0f, 1f);
    }

    void IncreaseGameTimer()
    {
        gameTimer++;
        UpdateGameTimerText();
    }
    void UpdateGameTimerText()
    {
        gameTimerText.text = "Round Time: " + gameTimer;
    }
}
