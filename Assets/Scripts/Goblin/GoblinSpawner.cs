using System.Collections;
using UnityEngine;

public class GoblinSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject goblin;

    int cycle = 1;

    private void Start()
    {
        SpawnGoblins();
    }

    public void SpawnGoblins()
    {
        SetNumberOfGoblinsToSpawn();
    }

    void SetNumberOfGoblinsToSpawn()
    {
        int numberOfGoblins = Random.Range(cycle * 2, (cycle + 15) * 2);
        int randomDelay = Random.Range(1, 3);
        cycle++;
        StartCoroutine(WaitAndInstantiateGoblins(randomDelay, numberOfGoblins));
    }

    void InstantiateGoblin()
    {
        Instantiate(goblin, transform.position, Quaternion.identity);
    }

    IEnumerator WaitAndInstantiateGoblins(int delay, int numberOfGoblins)
    {
        yield return new WaitForSeconds(delay);

        for (int i = 0; i < numberOfGoblins; i++)
        {
            InstantiateGoblin();
            yield return new WaitForSeconds(0.5f); // Adjust this delay as needed
        }
    }
}
