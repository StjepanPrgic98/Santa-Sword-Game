using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChristmasTree : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Slider hpSlider;

    [Header("Variables")]
    [SerializeField] int hp = 1000;

    private void Start()
    {
        UpdateHpSlider();
    }


    public void ReduceHp()
    {
        if(hp <= 0) { Destroy(); }
        hp--;
        UpdateHpSlider();
    }

    public int GetHp()
    {
        return hp;
    }

    void UpdateHpSlider()
    {
        hpSlider.value = hp;
    }


    void Destroy()
    {
        Destroy(gameObject);
    }

    public void IncreaseTreeHp()
    {
        hp += 300;
        if (hp > 1000) { hp = 1000; } 
        UpdateHpSlider();
    }
}
