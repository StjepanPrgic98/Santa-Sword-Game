using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChristmasTree : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Slider hpSlider;
    [SerializeField] TextMeshProUGUI blackHpText;
    [SerializeField] GameObject nukeExplosion;

    [Header("Components")]
    [SerializeField] BoxCollider2D boxCollider;

    [Header("Variables")]
    [SerializeField] int hp = 1000;

    int maxHp = 1000;

    private void Start()
    {
        UpdateHpDisplays();
    }


    public void ReduceHp()
    {
        if(hp <= 0) { DeathAnimation(); boxCollider.enabled = false; Destroy(gameObject, 0.7f); return; }
        hp--;
        UpdateHpDisplays();
    }

    public int GetHp()
    {
        return hp;
    }

    void UpdateHpDisplays()
    {
        UpdateHpSlider();
        UpdateHpText();
    }

    void UpdateHpSlider()
    {
        hpSlider.value = hp;
    }

    void UpdateHpText()
    {
        blackHpText.text = hp + "/" + maxHp;
    }

    public void IncreaseTreeHp()
    {
        hp += 300;
        if (hp > 1000) { hp = 1000; } 
        UpdateHpSlider();
    }

    void DeathAnimation()
    {    
        GameObject nukeExplosionObject = Instantiate(nukeExplosion, transform.position, Quaternion.identity);
        Destroy(nukeExplosionObject, 1);
    }

}
