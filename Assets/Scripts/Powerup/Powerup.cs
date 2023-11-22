using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [Header("References")]
    [SerializeField] PresentField presentField;

    [Header("Variables")]
    [SerializeField] bool presentMultiplyPowerup;
    [SerializeField] bool levelUpPowerup;
    [SerializeField] bool rotationPowerup;
    [SerializeField] bool repairPowerup;
    [SerializeField] bool moneyPowerup;
    [SerializeField] bool speedPowerup;
    [SerializeField] Vector3 outOfBoundsPosition = new Vector2(100,100);
    [SerializeField] List<Transform> spawnLocations;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Player") { return; }

        if (presentMultiplyPowerup) { presentField.MultiplyPresents(); }
        if (rotationPowerup) { presentField.MultiplyRotationSpeed(); }
        if (speedPowerup) { presentField.IncreaseMoveSpeed(); }
        if (repairPowerup) { presentField.IncreaseTreeHp(); }
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

    
}
