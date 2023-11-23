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
        SpawnAtRandomLocation();
    }

    void SetRespawnTime()
    {
        int respawnTime = Random.Range(15, 60);
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


}
