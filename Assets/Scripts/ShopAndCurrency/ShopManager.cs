using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShopManager
{
    public static int LevelOfPresentMultiplyPowerup { get; private set; }
    public static int LevelOfRotationSpeedPowerup { get; private set; }
    public static int LevelOfPlayerSpeedPowerup { get; private set; }
    public static int LevelOfLevelUpPowerup { get; private set; }
    public static int LevelOfChristmasTreeRepairPowerup { get; private set; }

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
