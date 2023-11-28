using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject unlockEverythingText;

    public void StartGame()
    {
        LevelManager.LoadLevel("Shop");
    }

    public void UnlockEverything()
    {
        ShopManager.UnlockEverything();
        TurnOnUnlockEverythingText();
    }

    void TurnOnUnlockEverythingText()
    {
        unlockEverythingText.SetActive(true);
        Invoke(nameof(TurnOffUnlockEverythingText), 2);
    }
    void TurnOffUnlockEverythingText()
    {
        unlockEverythingText.SetActive(false);
    }
}
