using System.Collections;
using UnityEngine;

public class SkeletonSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject skeleton;

    [Header("Variables")]
    [SerializeField] int baseNumberOfBats;
    [SerializeField] float baseRotationSpeed;

    int cycle = 1;

    private void Start()
    {
        SpawnSkeleton();
    }

    void SpawnSkeleton()
    {
        SpawnSkeletonAtRandomTime();
    }

    void SpawnSkeletonAtRandomTime()
    {
        int randomSpawnTime = Random.Range(40, 120);
        StartCoroutine(WaitAndSpawnSkeleton(randomSpawnTime));
    }

    IEnumerator WaitAndSpawnSkeleton(int delay)
    {
        yield return new WaitForSeconds(delay);

        GameObject skeletonObject = Instantiate(skeleton, transform.position, Quaternion.identity);

        SkeletonField skeletonField = skeletonObject.GetComponentInChildren<SkeletonField>();
        skeletonField.SetNumberOfBatsOnSpawn(CalculateNumberOfBatsToSpawn()); 
        skeletonField.SetBatRotationSpeedOnSpawn(CalculateRotationSpeed());
        skeletonField.SetLevelOfBatsOnSpawn(CalculateBatLevel());

        cycle++;
        SpawnSkeleton();
    }

    int CalculateNumberOfBatsToSpawn()
    {
        return baseNumberOfBats + Mathf.RoundToInt(baseNumberOfBats * 0.25f * cycle);
    }
    float CalculateRotationSpeed()
    {
        return baseRotationSpeed + (baseRotationSpeed * 0.2f * cycle);
    }
    int CalculateBatLevel()
    {
        return Random.Range(cycle-1, cycle+2);
    }
}
