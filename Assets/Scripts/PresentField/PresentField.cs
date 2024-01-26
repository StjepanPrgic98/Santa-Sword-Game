using Cinemachine;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PresentField : MonoBehaviour
{
    [Header("References")]
    [SerializeField] PlayerMovement player;
    [SerializeField] ChristmasTree christmasTree;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] AudioPlayer audioPlayer;
    [SerializeField] List<GameObject> presents;
    [SerializeField] SpriteRenderer levelNumberSpriteRenderer;
    [SerializeField] List<Sprite> levelNumberSprites;
    [SerializeField] TextMeshProUGUI powerupText;
    [SerializeField] TextMeshProUGUI doubleMoneyText;

    [Header("Variables")]
    [SerializeField] float rotationSpeed;
    [SerializeField] int numberOfPresents;
    [SerializeField] float initialCircleRadius;

    int level = 0;
    float doubleMoneyTimer = 30;
    float circleRadius;

    void Start()
    {
        ArrangeObjects();
        TurnOffDoubleMoneyEarned();
    }

    void Update()
    {
        RotatePresentField();
        UpdateDoubleMoneyTimerAndText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Goblin" || collision.tag == "Skeleton" || collision.tag == "Bat")
        {
            DecreaseLevel();
        }
    }

    public void IncreaseLevel()
    {
        if (level >= 5) { MultiplyPresents(); return; }

        level++;
        numberOfPresents = Mathf.RoundToInt(numberOfPresents / 1.5f);
        if (numberOfPresents <= 0) { numberOfPresents = 1; }

        rotationSpeed /= 1.2f;
        ArrangeObjects();
    }

    void DecreaseLevel()
    {
        if (level <= 0) { return; }

        level--;
        if (level > 5) { level = 4; }

        numberOfPresents -= numberOfPresents * 50 / 100;
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
        if(numberOfPresents > 40) { numberOfPresents = 40; }
        CalculateOptimalRadius();
        ArrangeObjects();
    }

    public void MultiplyRotationSpeed()
    {
        rotationSpeed *= 1.1f;
    }

    public void IncreaseMoveSpeed()
    {
        player.IncreaseMoveSpeed(0.25f);
    }

    public void IncreaseTreeHp()
    {
        christmasTree.IncreaseTreeHp(150);
    }

    void RotatePresentField()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    void TurnOffDoubleMoneyEarned()
    {
        CurrencyManager.SetDoubleCurrencyEarned(false);
    }

    void ArrangeObjects()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        CalculateOptimalRadius();

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
        UpdateLevelNumber();
    }


    void CalculateOptimalRadius()
    {
        float circumference = numberOfPresents * (presents[level].transform.localScale.x * 2 * Mathf.PI);
        circleRadius = Mathf.Max(circumference / (2 * Mathf.PI), initialCircleRadius);
    }

    void SetVirutalCameraDistance()
    {
        if (numberOfPresents < 15) { virtualCamera.m_Lens.OrthographicSize = 1.9f; }
        if (numberOfPresents > 15) { virtualCamera.m_Lens.OrthographicSize = 2.5f; }
        if (numberOfPresents > 20) { virtualCamera.m_Lens.OrthographicSize = 3.7f; }
        if (numberOfPresents > 30) { virtualCamera.m_Lens.OrthographicSize = 4.2f; }
        if (level == 5 && numberOfPresents > 8) { virtualCamera.m_Lens.OrthographicSize = 3.9f; }
        if (level == 5 && numberOfPresents > 15) { virtualCamera.m_Lens.OrthographicSize = 4.2f; }
        if (level == 5 && numberOfPresents > 25) { virtualCamera.m_Lens.OrthographicSize = 5.5f; }
    }

    void UpdateLevelNumber()
    {
        levelNumberSpriteRenderer.sprite = levelNumberSprites[level];
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

    void UpdateDoubleMoneyTimerAndText()
    {
        if (CurrencyManager.DoubleCurrency)
        {
            doubleMoneyTimer -= 1 * Time.deltaTime;   
            doubleMoneyText.text = "Double money: " + (int)doubleMoneyTimer;

            if (doubleMoneyTimer <= 0)
            {
                CurrencyManager.SetDoubleCurrencyEarned(false);
                doubleMoneyTimer = 30;
                doubleMoneyText.text = "";
            }
        }
    }
}
