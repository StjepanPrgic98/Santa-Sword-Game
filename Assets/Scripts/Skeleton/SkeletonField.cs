using System.Collections.Generic;
using UnityEngine;

public class SkeletonField : MonoBehaviour
{
    [Header("References")]
    [SerializeField] List<GameObject> bats;

    [Header("Variables")]
    [SerializeField] float rotationSpeed = 50f;
    [SerializeField] int numberOfBats = 15;
    [SerializeField] float initialCircleRadius = 2f;

    int level = 0;

    void Start()
    {
        InstantiateBats();
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    void InstantiateBats()
    {
        for (int i = 0; i < numberOfBats; i++)
        {
            float angle = i * (360f / numberOfBats);
            float radians = Mathf.Deg2Rad * angle;

            float x = transform.position.x + initialCircleRadius * Mathf.Cos(radians);
            float y = transform.position.y + initialCircleRadius * Mathf.Sin(radians);

            Vector3 newPosition = new Vector3(x, y, transform.position.z);

            GameObject newObject = Instantiate(bats[level], newPosition, Quaternion.identity);
            newObject.transform.parent = transform;
        }
    }

    public void SetNumberOfBatsOnSpawn(int bats)
    {
        numberOfBats = bats;
    }
    public void SetBatRotationSpeedOnSpawn(float rotationS)
    {
        rotationSpeed = rotationS;
    }
    public void SetLevelOfBatsOnSpawn(int batLevel)
    {
        if(batLevel > 5) { batLevel = 5; }
        level = batLevel;
    }
}
