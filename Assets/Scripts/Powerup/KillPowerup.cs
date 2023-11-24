using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillPowerup : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Powerup powerup;
    [SerializeField] TextMeshProUGUI moneyOwnedText;

    [Header("Variables")]
    [SerializeField] int numberOfEnemiesNeededForPowerup = 20;


    [HideInInspector] public int enemiesKilled = 0;


    private void Start()
    {
        UpdateMoneyOwnedText();
    }

    public void KillGoblin()
    {
        enemiesKilled++;
        CheckForNumberOfEnemiesDefeated();
        IncreaseMoney(1);
    }

    public void KillSkeleton()
    {
        enemiesKilled += 3;
        CheckForNumberOfEnemiesDefeated();
        IncreaseMoney(10);
    }

    private void CheckForNumberOfEnemiesDefeated()
    {
        if (enemiesKilled >= numberOfEnemiesNeededForPowerup)
        {
            enemiesKilled = 0;
            powerup.GiveRandomPowerup();
        }
    }

    void IncreaseMoney(int money)
    {
        CurrencyManager.IncreaseCurrency(money);
        UpdateMoneyOwnedText();
    }

    void UpdateMoneyOwnedText()
    {
        moneyOwnedText.text = "Money: " + CurrencyManager.CurrencyOwned;
    }
}
