using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [Header("References")]
    [SerializeField] PresentField presentField;
    [SerializeField] TextMeshProUGUI powerupText;

    [Header("Variables")]
    [SerializeField] bool presentMultiplyPowerup;
    [SerializeField] bool levelUpPowerup;
    [SerializeField] bool rotationPowerup;
    [SerializeField] bool repairPowerup;
    [SerializeField] bool moneyPowerup;
    [SerializeField] bool speedPowerup;
    [SerializeField] List<Transform> spawnLocations;
    [SerializeField] Vector3 outOfBoundsPosition = new Vector2(100, 100);

    const string presentMultiplyText = "+ Presents!";
    const string rotationText = "+ Rotation Speed!";
    const string repairText = "+ Tree HP!";
    const string speedText = "+ Player Speed!";
    const string levelUpText = "+ Present Level!";

    int minRange = 0;
    int maxRange = 0;

    int baseMinRange = 50;
    int baseMaxRange = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Powerup") { SpawnAtRandomLocation(); }
        if(collision.tag != "Player") { return; }

        DisplayPowerupText();

        if (presentMultiplyPowerup) { presentField.MultiplyPresents(); }
        if (rotationPowerup) { presentField.MultiplyRotationSpeed(); }
        if (speedPowerup) { presentField.IncreaseMoveSpeed(); }
        if (repairPowerup) { presentField.IncreaseTreeHp(); }
        if (levelUpPowerup) { presentField.IncreaseLevel(); }
        transform.position = outOfBoundsPosition;

        SetRespawnTime();
        
    }

    private void Start()
    {
        SetMinAndMaxRangeOfTimeToRespawn();
        if (minRange == 0 && maxRange == 0) { return; }
        SpawnAtRandomLocation();
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

    void DisplayPowerupText()
    {
        if (presentMultiplyPowerup) { powerupText.text = presentMultiplyText; }
        if (rotationPowerup) { powerupText.text = rotationText; }
        if (repairPowerup) { powerupText.text = repairText; }
        if (speedPowerup) { powerupText.text = speedText; }
        if (levelUpPowerup) { powerupText.text = levelUpText; }
        Invoke(nameof(ResetPowerupText), 2);
    }

    void ResetPowerupText()
    {
        powerupText.text = "";
    }

    public void GiveRandomPowerup()
    {
        int randomPowerup = Random.Range(0, 5);
        if(randomPowerup == 0) { presentField.MultiplyPresents(); powerupText.text = presentMultiplyText; }
        if(randomPowerup == 1) { presentField.MultiplyRotationSpeed(); powerupText.text = rotationText; }
        if(randomPowerup == 2) { presentField.IncreaseMoveSpeed(); powerupText.text = speedText; }
        if(randomPowerup == 3) { presentField.IncreaseTreeHp(); powerupText.text = repairText; }
        if(randomPowerup == 4) { presentField.IncreaseLevel(); powerupText.text = levelUpText; }
        Invoke(nameof(ResetPowerupText), 2);
    }

    void SetMinAndMaxRangeOfTimeToRespawn()
    {
        if (presentMultiplyPowerup)
        {
            if (ShopManager.LevelOfPresentMultiplyPowerup == 0) { minRange = 0; maxRange = 0; return; }
            minRange = Mathf.RoundToInt(baseMinRange / ShopManager.LevelOfPresentMultiplyPowerup + 5);
            maxRange = Mathf.RoundToInt(baseMaxRange / ShopManager.LevelOfPresentMultiplyPowerup + 25);
        }
        if (rotationPowerup)
        {
            if (ShopManager.LevelOfRotationSpeedPowerup == 0) { minRange = 0; maxRange = 0; return; }
            minRange = Mathf.RoundToInt(baseMinRange / ShopManager.LevelOfRotationSpeedPowerup + 5);
            maxRange = Mathf.RoundToInt(baseMaxRange / ShopManager.LevelOfRotationSpeedPowerup + 25);
        }
        if (speedPowerup)
        {
            if (ShopManager.LevelOfPlayerSpeedPowerup == 0) { minRange = 0; maxRange = 0; return; }
            minRange = Mathf.RoundToInt(baseMinRange / ShopManager.LevelOfPlayerSpeedPowerup + 5);
            maxRange = Mathf.RoundToInt(baseMaxRange / ShopManager.LevelOfPlayerSpeedPowerup + 25);
        }
        if (levelUpPowerup)
        {
            if (ShopManager.LevelOfLevelUpPowerup == 0) { minRange = 0; maxRange = 0; return; }
            minRange = Mathf.RoundToInt(baseMinRange / ShopManager.LevelOfLevelUpPowerup + 5);
            maxRange = Mathf.RoundToInt(baseMaxRange / ShopManager.LevelOfLevelUpPowerup + 25);
        }
        if (repairPowerup)
        {
            if (ShopManager.LevelOfChristmasTreeRepairPowerup == 0) { minRange = 0; maxRange = 0; return; }
            minRange = Mathf.RoundToInt(baseMinRange / ShopManager.LevelOfChristmasTreeRepairPowerup + 5);
            maxRange = Mathf.RoundToInt(baseMaxRange / ShopManager.LevelOfChristmasTreeRepairPowerup + 25);
        }
    }


}
