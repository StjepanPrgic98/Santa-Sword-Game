using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChristmasTree : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject nukeExplosion;
    [SerializeField] AudioPlayer audioPlayer;
    [SerializeField] Slider hpSlider;
    [SerializeField] TextMeshProUGUI blackHpText;
    [SerializeField] TextMeshProUGUI loadingShopText;
    
    [Header("Components")]
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] SpriteRenderer spriteRenderer;

    [Header("Variables")]
    [SerializeField] int hp;
    [SerializeField] int maxHp;
    [SerializeField] float turnOffSpriteRendererTime;
    [SerializeField] float loadShopLevelTime;

    const string loadShopLevelText = "Loading Shop...";

    private void Start()
    {
        UpdateHpDisplays();
    }

    public int GetHp()
    {
        return hp;
    }

    public void ReduceHp()
    {
        if(hp <= 0) { DestroyChristmasTree(); return; }
 
        hp--;
        UpdateHpDisplays();
    }
    public void IncreaseTreeHp(int treeRepairAmount)
    {
        hp += treeRepairAmount;
        if (hp > maxHp) { hp = maxHp; }
        UpdateHpDisplays();
    }

    void DestroyChristmasTree()
    {
        boxCollider.enabled = false;
        DeathAnimation();
        Invoke(nameof(TurnOffTreeSpriteRenderer), turnOffSpriteRendererTime);
        LoadShop();
    }
    void DeathAnimation()
    {
        audioPlayer.PlayChristmasTreeExplosionClip();
        InstantiateExplosion();
    }

    void InstantiateExplosion()
    {
        GameObject nukeExplosionObject = Instantiate(nukeExplosion, transform.position, Quaternion.identity);
        Destroy(nukeExplosionObject, 1);
    }

    void TurnOffTreeSpriteRenderer()
    {
        spriteRenderer.enabled = false;
    }

    void LoadShop()
    {
        loadingShopText.text = loadShopLevelText;
        Invoke(nameof(LoadShopLevel), loadShopLevelTime);
    }
    void LoadShopLevel()
    {
        LevelManager.LoadLevel("Shop");
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

}
