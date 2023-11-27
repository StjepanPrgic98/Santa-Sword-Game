using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D boxCollider;

    ChristmasTree christmasTree;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Present")
        {
            DestroyGoblin();
        }

        if (collision.tag == "ChristmasTree")
        {
            SetAttackAnimation(true);

            christmasTree = FindObjectOfType<ChristmasTree>();
            StartCoroutine(DealDamageOverTime(1f));
        }
    }

    void DestroyGoblin()
    {
        boxCollider.enabled = false;
        Destroy(gameObject, 0.5f);
        PlayDeathAnimation();
        IncreaseGoblinKillCountForRandomPowerup();
    }

    void PlayDeathAnimation()
    {
        SetAttackAnimation(false);
        animator.SetBool("isDead", true);
    }

    void SetAttackAnimation(bool state)
    {
        animator.SetBool("isAttacking", state);
    }
    void IncreaseGoblinKillCountForRandomPowerup()
    {
        FindObjectOfType<KillPowerup>().KillGoblin();
    }

    IEnumerator DealDamageOverTime(float delay)
    {
        while (animator.GetBool("isAttacking"))
        {
            yield return new WaitForSeconds(delay);

            if (christmasTree.GetHp() <= 0) 
            { 
                christmasTree.ReduceHp();
                DestroyGoblin();
                break; 
            }

            christmasTree.ReduceHp();
        }
    }
}
