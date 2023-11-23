using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPowerup : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Powerup powerup;

    [Header("Variables")]
    [SerializeField] int numberOfEnemiesNeededForPowerup = 20;


    [HideInInspector] public int enemiesKilled = 0;


    public void KillGoblin()
    {
        enemiesKilled++;
        CheckForNumberOfEnemiesDefeated();
    }

    public void KillSkeleton()
    {
        enemiesKilled += 3;
        CheckForNumberOfEnemiesDefeated();
    }

    private void CheckForNumberOfEnemiesDefeated()
    {
        if (enemiesKilled >= numberOfEnemiesNeededForPowerup)
        {
            enemiesKilled = 0;
            powerup.GiveRandomPowerup();
        }
    }
}
