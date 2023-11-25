using Cinemachine;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PresentField : MonoBehaviour
{
    [Header("References")]
    [SerializeField] List<GameObject> presents;
    [SerializeField] PlayerMovement player;
    [SerializeField] ChristmasTree christmasTree;
    [SerializeField] TextMeshProUGUI powerupText;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] AudioPlayer audioPlayer;

    [Header("Variables")]
    [SerializeField] float rotationSpeed = 50f;
    [SerializeField] int numberOfPresents = 15;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Goblin" || collision.tag == "Skeleton" || collision.tag == "Bat")
        {
            DecreaseLevel();
        }
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
        }

        SetVirutalCameraDistance();
    }

    public void IncreaseLevel()
    {
        level++;
        numberOfPresents = Mathf.RoundToInt(numberOfPresents / 1.5f);
        if(numberOfPresents <= 0) { numberOfPresents = 1; }
        if(level > 5) { level = 5; numberOfPresents += 2; }
        rotationSpeed /= 1.2f;
        ArrangeObjects();
    }

    void DecreaseLevel()
    {
        level--;
        numberOfPresents = Mathf.RoundToInt(numberOfPresents * 1.5f);
        if (numberOfPresents == 0) { numberOfPresents = 1; }
        if (level > 5) { level = 4; }
        if(level < 0) { level = 0; }
        rotationSpeed *= 1.1f;
        ArrangeObjects();
        WritePowerupText("- Level!");
    }

    public void ReducePresents()
    {
        numberOfPresents--;
        audioPlayer.PlayHitClip();
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
        float circumference = numberOfPresents * (presents[level].transform.localScale.x * 2 * Mathf.PI);

        // Calculate the optimal radius to achieve the desired circumference
        circleRadius = Mathf.Max(circumference / (2 * Mathf.PI), initialCircleRadius);
    }

    void WritePowerupText(string text)
    {
        powerupText.text = text;
        Invoke(nameof(ResetPowerupText), 2);
    }
    void ResetPowerupText()
    {
        powerupText.text = "";
    }

    void SetVirutalCameraDistance()
    {
        if(numberOfPresents < 15) { virtualCamera.m_Lens.OrthographicSize = 1.9f; }
        if(numberOfPresents > 15) { virtualCamera.m_Lens.OrthographicSize = 2.5f; }
        if (level == 4 || level == 5 && numberOfPresents > 15) { virtualCamera.m_Lens.OrthographicSize = 3f; }
        if (numberOfPresents > 30) { virtualCamera.m_Lens.OrthographicSize = 3.5f; }
    }

    float circleRadius; // Moved the declaration of circleRadius to the class level
}
