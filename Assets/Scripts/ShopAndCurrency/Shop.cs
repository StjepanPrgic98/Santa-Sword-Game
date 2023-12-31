using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject upgradeButton;
    [SerializeField] Sprite levelUnlockedSprite;
    [SerializeField] Sprite lockedLevelSprite;
    [SerializeField] List<Image> levelImages;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] TextMeshProUGUI price;
    [SerializeField] TextMeshProUGUI shopText;
    [SerializeField] TextMeshProUGUI moneyOwnedText;
   
    const string multiplyPowerupDescription = "Multiplies presents by 1.5x";
    const string multiplyRotationSpeedDescription = "Multiplies rotation speed by 1.1x";
    const string increasePlayerSpeedDescription = "Increases player speed";
    const string increaseLevelDescription = "Increases present level";
    const string repairDescription = "Restores Christmas Tree HP by 150";
    const string doubleMoneyDescription = "Doubles money earned for 30 seconds";

    const string upgradeSucces = "Upgraded!";
    const string notEnoughMoney = "Not enough money!";

    int nextUpgradeLevelPrice = 0;
    string powerUpToUpgrade = "";

    private void Start()
    {
        DisplayMoneyOwned();
    }

    public void DisplayPowerupInformation(string powerupName)
    {
        switch (powerupName)
        {
            case "Multiply":
                description.text = multiplyPowerupDescription;
                CheckForPowerupUnlockedLevels(ShopManager.LevelOfPresentMultiplyPowerup);
                GetPowerupPrice(ShopManager.LevelOfPresentMultiplyPowerup, ShopManager.BasePowerupLevelPrice);
                break;
            case "Rotation":
                description.text = multiplyRotationSpeedDescription;
                CheckForPowerupUnlockedLevels(ShopManager.LevelOfRotationSpeedPowerup);
                GetPowerupPrice(ShopManager.LevelOfRotationSpeedPowerup, ShopManager.BasePowerupLevelPrice);
                break;
            case "Speed":
                description.text = increasePlayerSpeedDescription;
                CheckForPowerupUnlockedLevels(ShopManager.LevelOfPlayerSpeedPowerup);
                GetPowerupPrice(ShopManager.LevelOfPlayerSpeedPowerup, ShopManager.BasePowerupLevelPrice);
                break;
            case "Level":
                description.text = increaseLevelDescription;
                CheckForPowerupUnlockedLevels(ShopManager.LevelOfLevelUpPowerup);
                GetPowerupPrice(ShopManager.LevelOfLevelUpPowerup, ShopManager.BasePowerupLevelPrice);
                break;
            case "Repair":
                description.text = repairDescription;
                CheckForPowerupUnlockedLevels(ShopManager.LevelOfChristmasTreeRepairPowerup);
                GetPowerupPrice(ShopManager.LevelOfChristmasTreeRepairPowerup, ShopManager.BasePowerupLevelPrice);
                break;
            case "DoubleMoney":
                description.text = doubleMoneyDescription;
                CheckForPowerupUnlockedLevels(ShopManager.LevelOfDoubleMoneyPowerup);
                GetPowerupPrice(ShopManager.LevelOfDoubleMoneyPowerup, ShopManager.BasePowerupLevelPrice);
                break;
        }
        powerUpToUpgrade = powerupName;
    }

    void CheckForPowerupUnlockedLevels(int powerupLevel)
    {
        foreach (var image in levelImages)
        {
            image.enabled = true;
            image.sprite = lockedLevelSprite;
        }
        if (powerupLevel >= 5) { upgradeButton.SetActive(false); }
        else { upgradeButton.SetActive(true); }

        if (powerupLevel == 0) { return; }
        for (int i = 0; i < powerupLevel; i++)
        {
            levelImages[i].sprite = levelUnlockedSprite;
        }
    }

    void GetPowerupPrice(int powerupLevel, int powerupPrice)
    {
        int nextLevelPrice = (powerupPrice * powerupLevel) * 2;
        if(powerupLevel == 0) { nextLevelPrice = ShopManager.BasePowerupLevelPrice; }
        if(powerupLevel >= 5) { price.text = "Max level!"; return; }
        price.text = "Next level price: " + nextLevelPrice;
        nextUpgradeLevelPrice = nextLevelPrice;
    }

    public void UpgradePowerup()
    {
        if (!CheckIfPlayerHasEnoughMoney(CurrencyManager.CurrencyOwned, nextUpgradeLevelPrice)) { return; };
        switch (powerUpToUpgrade)
        {
            case "Multiply":
                ShopManager.IncreaseLevelOfPresentMultiplyPowerup();
                break;
            case "Rotation":
                ShopManager.IncreaseLevelOfRotationSpeedPowerup();
                break;
            case "Speed":
                ShopManager.IncreaseLevelOfPlayerSpeedPowerup();
                break;
            case "Level":
                ShopManager.IncreaseLevelOfLevelUpPowerup();
                break;
            case "Repair":
                ShopManager.IncreaseLevelOfChristmasTreeRepairPowerup();
                break;
            case "DoubleMoney":
                ShopManager.IncreaseLevelOfDoubleMoneyPowerup();
                break;
        }

        DisplayPowerupInformation(powerUpToUpgrade);
        DisplayMoneyOwned();
    }

    bool CheckIfPlayerHasEnoughMoney(int moneyOwned, int moneyNeeded)
    {
        if(moneyOwned >= moneyNeeded) 
        {
            CurrencyManager.DecreaseCurrency(moneyNeeded);
            DisplayPurchaseText(upgradeSucces); 
            return true;
        }

        DisplayPurchaseText(notEnoughMoney);
        return false;
    }

    void DisplayPurchaseText(string text)
    {
        shopText.text = text;
        Invoke(nameof(ResetPurchaseText), 2);
    }

    void ResetPurchaseText()
    {
        shopText.text = "";
    }

    void DisplayMoneyOwned()
    {
        moneyOwnedText.text = "Money owned: " + CurrencyManager.CurrencyOwned;
    }

    public void StartGame()
    {
        LevelManager.LoadLevel("Main");
    }
}
