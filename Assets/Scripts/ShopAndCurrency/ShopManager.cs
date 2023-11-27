using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShopManager
{
    public static int LevelOfPresentMultiplyPowerup { get; private set; } = 1;
    public static int LevelOfRotationSpeedPowerup { get; private set; } = 1;
    public static int LevelOfPlayerSpeedPowerup { get; private set; } = 0;
    public static int LevelOfLevelUpPowerup { get; private set; } = 0;
    public static int LevelOfChristmasTreeRepairPowerup { get; private set; } = 0;
    public static int LevelOfDoubleMoneyPowerup { get; set; } = 0;

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
    public static void IncreaseLevelOfDoubleMoneyPowerup()
    {
        LevelOfDoubleMoneyPowerup++;
    }

}
