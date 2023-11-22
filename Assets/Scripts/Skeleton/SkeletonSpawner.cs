using System.Collections;
using UnityEngine;

public class SkeletonSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject skeleton;

    int cycle = 1;
    int baseNumberOfBats = 2;
    float baseRotationSpeed = 50;
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
        int randomSpawnTime = Random.Range(40, 100);
        StartCoroutine(WaitAndSpawnSkeleton(randomSpawnTime));
    }

    IEnumerator WaitAndSpawnSkeleton(int delay)
    {
        yield return new WaitForSeconds(delay);

        GameObject skeletonObject = Instantiate(skeleton, transform.position, Quaternion.identity);

        SkeletonField skeletonField = skeletonObject.GetComponentInChildren<SkeletonField>();
        skeletonField.SetNumberOfBatsOnSpawn(CalculateNumberOfBatsToSpawn()); 
        skeletonField.SetBatRotationSpeedOnSpawn(CalculateRotationSpeed());

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
}
