using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartWavesTimer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI startWavesTimer;


    int timer = 30;

    const string enemiesSpawnText = "Enemies will spawn in: ";

    private void Start()
    {
        InvokeRepeating(nameof(ReduceTimer), 0f, 1f);
    }

    void ReduceTimer()
    {
        timer--;
        startWavesTimer.text = enemiesSpawnText + timer;
        if(timer == 0) { TurnOffTextAndScript(); }
    }

    void TurnOffTextAndScript()
    {
        CancelInvoke(nameof(ReduceTimer));
        startWavesTimer.text = "";
        this.enabled = false;
    }
}
