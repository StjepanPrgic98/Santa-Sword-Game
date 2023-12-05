using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TreePowerSuply : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI powerSuplyText;
    [SerializeField] Slider repairTimerSlider;
    [SerializeField] GameObject repairTimerSliderObject;
    [SerializeField] GameObject repairingTextObject;
    [SerializeField] List<PowerSuplyUnit> powerSuplyUnits;

    float repairTimer = 0f;

    const string repairPowerSuply0 = "Power Suply 1 Broken! \n Damage Dealth to Christmas Tree Increased";
    const string repairPowerSuply1 = "Power Suply 2 Broken! \n Damage Dealth to Christmas Tree Increased\"";
    const string repairPowerSuply2 = "Power Suply 3 Broken! \n Damage Dealth to Christmas Tree Increased\"";

    int currentPowerSuplyInRepair = 0;

    public int LevelOfTreeDamageIncrease { get; private set; } = 1;

    private void Start()
    {
        BreakRandomPowerSuplyAtRandomTime();
    }

    public void StartRepair(int id)
    {
        InvokeRepeating(nameof(IncreaseRepairTimer), 0f, 1f);
        currentPowerSuplyInRepair = id;
        SetRepairSliderActiveState(true);
    }
    void IncreaseRepairTimer()
    {
        repairTimer += 1;
        UpdateReapirTimerSlider();
        CheckTimerToRepairPowerSuply();
    }
    void UpdateReapirTimerSlider()
    {
        repairTimerSlider.value = repairTimer;
    }
    void SetRepairSliderActiveState(bool state)
    {
        repairTimer = 0;
        repairTimerSliderObject.SetActive(state);
        repairingTextObject.SetActive(state);
    }
    void CheckTimerToRepairPowerSuply()
    {
        if (repairTimer >= 10)
        {
            RepairPowerSuply();
            SetRepairSliderActiveState(false);
            CancelInvoke(nameof(IncreaseRepairTimer));
            currentPowerSuplyInRepair = 10;
        }
    }
    void RepairPowerSuply()
    {
        powerSuplyUnits[currentPowerSuplyInRepair].RepairPowerSuply();
        LevelOfTreeDamageIncrease--;
    }

    void BreakRandomPowerSuplyAtRandomTime()
    {
        int randomDelay = Random.Range(15, 20);
        Invoke(nameof(BreakRandomPowerSuply), randomDelay);
    }

    void BreakRandomPowerSuply()
    {
        int randomPowerSuply = Random.Range(0, 3);

        if (powerSuplyUnits[randomPowerSuply].CheckIfBroken())
        {
            foreach (var powerSuply in powerSuplyUnits)
            {
                if(powerSuply.CheckIfBroken() == false) 
                { 
                    powerSuply.BreakPowerSuply();
                    LevelOfTreeDamageIncrease++;
                    break; 
                }
            }
        }
        else
        {
            powerSuplyUnits[randomPowerSuply].BreakPowerSuply();
            LevelOfTreeDamageIncrease++;
        }
        
        BreakRandomPowerSuplyAtRandomTime();
        CheckWhatPowerSuplyTextToDisplay(randomPowerSuply);
    }

    void CheckWhatPowerSuplyTextToDisplay(int powerSuplyId)
    {
        if(powerSuplyId == 0) { DisplayPowerSuplyText(repairPowerSuply0); }
        if(powerSuplyId == 1) { DisplayPowerSuplyText(repairPowerSuply1); }
        if(powerSuplyId == 2) { DisplayPowerSuplyText(repairPowerSuply2); }
    }

    void DisplayPowerSuplyText(string suplyText)
    {
        powerSuplyText.text = suplyText;
        Invoke(nameof(TurnOffPowerSuplyText), 5);
    }
    void TurnOffPowerSuplyText()
    {
        powerSuplyText.text = "";
    }
}
