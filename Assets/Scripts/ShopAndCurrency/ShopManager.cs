using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShopManager
{
    public static int LevelOfPresentMultiplyPowerup { get; private set; } = 5;
    public static int LevelOfRotationSpeedPowerup { get; private set; } = 4;
    public static int LevelOfPlayerSpeedPowerup { get; private set; } = 3;
    public static int LevelOfLevelUpPowerup { get; private set; } = 2;
    public static int LevelOfChristmasTreeRepairPowerup { get; private set; } = 0;

    public static int BasePowerupLevelPrice { get; set; } = 50;

    public static void IncreaseLevelOfPresentMultiplyPowerup()
    {
        LevelOfPresentMultiplyPowerup++;
    }
    public static void IncreaseLevelOfRotationSpeedPowerup()
    {
        LevelOfRotationSpeedPowerup++;
    }
    public static void IncreaseLevelOfPlayerSpeedPowerup()
    {
        LevelOfPlayerSpeedPowerup++;
    }
    public static void IncreaseLevelOfLevelUpPowerup()
    {
        LevelOfLevelUpPowerup++;
    }
    public static void IncreaseLevelOfChristmasTreeRepairPowerup()
    {
        LevelOfChristmasTreeRepairPowerup++;
    }

}
