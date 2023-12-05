using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSuplyUnit : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] TreePowerSuply treePowerSuply;

    [Header("Variables")]
    [SerializeField] int id;

    bool powerSuplyBroken = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && powerSuplyBroken == true)
        {
            treePowerSuply.StartRepair(id);
        }
    }

    public bool CheckIfBroken()
    {
        return powerSuplyBroken;
    }
    public void BreakPowerSuply()
    {
        powerSuplyBroken = true;
    }
    public void RepairPowerSuply()
    {

    }

}
