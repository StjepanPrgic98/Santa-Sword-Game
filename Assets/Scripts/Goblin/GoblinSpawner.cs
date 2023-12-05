using System.Collections;
using UnityEngine;

public class GoblinSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject goblin;

    int cycle = 1;

    private void Start()
    {
        SpawnGoblinsAtRandomTime();   
    }

    public void SpawnGoblinsAtRandomTime()
    {
        int randomDelay = Random.Range(30, 80);
        StartCoroutine(WaitAndSpawnGoblinsAtRandomTime(randomDelay));
    }
    IEnumerator WaitAndSpawnGoblinsAtRandomTime(int delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnGoblins();
    }
    void SpawnGoblins()
    {
        SetNumberOfGoblinsToSpawn();
    }

    void SetNumberOfGoblinsToSpawn()
    {
        int minRange = cycle * 2;
        int maxRange = (int)Mathf.Round(Mathf.Pow(cycle, 2));
            
        int numberOfGoblins = Random.Range(minRange, maxRange);
        int randomDelay = Random.Range(1, 3);

        cycle +=2;
        StartCoroutine(WaitAndInstantiateGoblins(randomDelay, numberOfGoblins));
    }

    IEnumerator WaitAndInstantiateGoblins(int delay, int numberOfGoblins)
    {
        yield return new WaitForSeconds(delay);

        for (int i = 0; i < numberOfGoblins; i++)
        {
            InstantiateGoblin();
            yield return new WaitForSeconds(0.5f);
        }

        SpawnGoblinsAtRandomTime(); // Called for continuos loop
    }

    void InstantiateGoblin()
    {
        Instantiate(goblin, transform.position, Quaternion.identity);
    }

}
