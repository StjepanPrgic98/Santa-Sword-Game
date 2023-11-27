using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [Header("References")]
    [SerializeField] PresentField presentField;
    [SerializeField] AudioPlayer audioPlayer;
    [SerializeField] TextMeshProUGUI powerupText;

    [Header("Variables")]
    [SerializeField] bool presentMultiplyPowerup;
    [SerializeField] bool levelUpPowerup;
    [SerializeField] bool rotationPowerup;
    [SerializeField] bool repairPowerup;
    [SerializeField] bool moneyPowerup;
    [SerializeField] bool speedPowerup;
    [SerializeField] List<Transform> spawnLocations;
    [SerializeField] Vector3 outOfBoundsPosition;

    const string presentMultiplyText = "+ Presents!";
    const string rotationText = "+ Rotation Speed!";
    const string repairText = "+ Tree HP!";
    const string speedText = "+ Player Speed!";
    const string levelUpText = "+ Present Level!";
    const string doubleMoneyText = "Double Money For 30 Seconds!";

    int minRange = 0;
    int maxRange = 0;

    int baseMinRange = 50;
    int baseMaxRange = 100;

    private void Start()
    {
        SetMinAndMaxRangeOfTimeToRespawn();
        if (minRange == 0 && maxRange == 0) { return; }
        SpawnAtRandomLocation();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Powerup") { SpawnAtRandomLocation(); }
        if (collision.tag != "Player") { return; }

        if (presentMultiplyPowerup) { ActivatePresentMultiplyPowerup(); }
        if (rotationPowerup) { ActivateRotationSpeedPowerup(); }
        if (speedPowerup) { ActivatePlayerSpeedPowerup(); }
        if (repairPowerup) { ActivateRepairPowerup(); }
        if (levelUpPowerup) { ActivateLevelUpPowerup(); }
        if (moneyPowerup) { ActivateDoubleMoneyPowerup(); }
        transform.position = outOfBoundsPosition;

        SetRespawnTime();
        audioPlayer.PlayCollectPowerupClip();

    }
    public void GiveRandomPowerup()
    {
        int randomPowerup = Random.Range(0, 5);
        if (randomPowerup == 0) { ActivatePresentMultiplyPowerup(); }
        if (randomPowerup == 1) { ActivateRotationSpeedPowerup(); }
        if (randomPowerup == 2) { ActivatePlayerSpeedPowerup(); }
        if (randomPowerup == 3) { ActivateRepairPowerup(); }
        if (randomPowerup == 4) { ActivateDoubleMoneyPowerup(); }
    }

    void ActivatePresentMultiplyPowerup()
    {
        presentField.MultiplyPresents(); 
        DisplayPowerupText(presentMultiplyText);
    }
    void ActivateRotationSpeedPowerup()
    {
        presentField.MultiplyRotationSpeed(); 
        DisplayPowerupText(rotationText);
    }
    void ActivatePlayerSpeedPowerup()
    {
        presentField.IncreaseMoveSpeed(); 
        DisplayPowerupText(speedText);
    }
    void ActivateRepairPowerup()
    {
        presentField.IncreaseTreeHp(); 
        DisplayPowerupText(repairText);
    }
    void ActivateLevelUpPowerup()
    {
        presentField.IncreaseLevel(); 
        DisplayPowerupText(levelUpText);
    }
    void ActivateDoubleMoneyPowerup()
    {
        CurrencyManager.SetDoubleCurrencyEarned(true); 
        DisplayPowerupText(doubleMoneyText);
    }

    void SetRespawnTime()
    {
        int respawnTime = Random.Range(minRange, maxRange);
        StartCoroutine(WaitAndRespawnPowerUp(respawnTime));
    }
    IEnumerator WaitAndRespawnPowerUp(int delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnAtRandomLocation();
    }

    void SpawnAtRandomLocation()
    {
        int randomNumber = Random.Range(0, spawnLocations.Count);
        transform.position = spawnLocations[randomNumber].position;
    }

    void DisplayPowerupText(string text)
    {
        powerupText.text = text;
        Invoke(nameof(ResetPowerupText), 2);
    }

    void ResetPowerupText()
    {
        powerupText.text = "";
    }

    void SetMinAndMaxRangeOfTimeToRespawn()
    {
        if (presentMultiplyPowerup) { SetMinAndMaxRangeBasedOnPowerupLevel(ShopManager.LevelOfPresentMultiplyPowerup); }
        if (rotationPowerup) { SetMinAndMaxRangeBasedOnPowerupLevel(ShopManager.LevelOfRotationSpeedPowerup); }  
        if (speedPowerup) { SetMinAndMaxRangeBasedOnPowerupLevel(ShopManager.LevelOfPlayerSpeedPowerup); }   
        if (levelUpPowerup) { SetMinAndMaxRangeBasedOnPowerupLevel(ShopManager.LevelOfLevelUpPowerup); }  
        if (repairPowerup) { SetMinAndMaxRangeBasedOnPowerupLevel(ShopManager.LevelOfChristmasTreeRepairPowerup); }
        if (moneyPowerup) { SetMinAndMaxRangeBasedOnPowerupLevel(ShopManager.LevelOfDoubleMoneyPowerup); }    
    }

    void SetMinAndMaxRangeBasedOnPowerupLevel(int level)
    {
        if (level == 0) { minRange = 0; maxRange = 0; return; }
        minRange = Mathf.RoundToInt(baseMinRange / level + 5);
        maxRange = Mathf.RoundToInt(baseMaxRange / level + 25);

        if (moneyPowerup) { minRange = 31; } //Prevents activating up before last one runs out
    }


}
