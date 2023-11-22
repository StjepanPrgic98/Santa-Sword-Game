using System.Collections.Generic;
using UnityEngine;

public class PresentField : MonoBehaviour
{
    [Header("References")]
    [SerializeField] List<GameObject> presents;
    [SerializeField] PlayerMovement player;
    [SerializeField] ChristmasTree christmasTree;

    [Header("Variables")]
    [SerializeField] float rotationSpeed = 50f;
    [SerializeField] int numberOfPresents = 15;
    [SerializeField] Vector3 presentScale;
    [SerializeField] float initialCircleRadius = 2f;

    int level = 0;

    void Start()
    {
        ArrangeObjects();
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    void ArrangeObjects()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        CalculateOptimalRadius(); // Calculate the optimal radius before arranging objects

        for (int i = 0; i < numberOfPresents; i++)
        {
            float angle = i * (360f / numberOfPresents);
            float radians = Mathf.Deg2Rad * angle;

            float x = transform.position.x + circleRadius * Mathf.Cos(radians);
            float y = transform.position.y + circleRadius * Mathf.Sin(radians);

            Vector3 newPosition = new Vector3(x, y, transform.position.z);

            GameObject newObject = Instantiate(presents[level], newPosition, Quaternion.identity);
            newObject.transform.parent = transform;

            //newObject.transform.localScale = presentScale;
        }
    }

    public void IncreaseLevel()
    {
        level++;
    }

    public void ReducePresents()
    {
        numberOfPresents--;
    }

    public void MultiplyPresents()
    {
        numberOfPresents += (int)Mathf.Round(numberOfPresents * 50 / 100) + 1;
        CalculateOptimalRadius();
        ArrangeObjects();
    }

    public void MultiplyRotationSpeed()
    {
        rotationSpeed *= 1.2f;
    }

    public void IncreaseMoveSpeed()
    {
        player.IncreaseMoveSpeed(0.5f);
    }

    public void IncreaseTreeHp()
    {
        christmasTree.IncreaseTreeHp();
    }

    void CalculateOptimalRadius()
    {
        // Calculate the circumference needed to distribute presents evenly
        float circumference = numberOfPresents * (presentScale.x * 2 * Mathf.PI);

        // Calculate the optimal radius to achieve the desired circumference
        circleRadius = Mathf.Max(circumference / (2 * Mathf.PI), initialCircleRadius);
    }

    float circleRadius; // Moved the declaration of circleRadius to the class level
}
