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
        if (collision.tag == "Present" || collision.tag == "Player")
        {
            PlayDeathAnimation();
        }

        if (collision.tag == "ChristmasTree")
        {
            SetAttackAnimation(true);

            christmasTree = FindObjectOfType<ChristmasTree>();
            StartCoroutine(DealDamageOverTime(1f));
        }
    }

    void PlayDeathAnimation()
    {
        animator.SetBool("isDead", true);
        boxCollider.enabled = false;
        Destroy(gameObject, 0.5f);
        FindObjectOfType<KillPowerup>().KillGoblin();
    }

    void SetAttackAnimation(bool state)
    {
        animator.SetBool("isAttacking", state);
    }

    IEnumerator DealDamageOverTime(float delay)
    {
        while (animator.GetBool("isAttacking"))
        {
            yield return new WaitForSeconds(delay);
            if (christmasTree.GetHp() <= 0) { christmasTree.ReduceHp(); SetAttackAnimation(false); PlayDeathAnimation(); break; }
            christmasTree.ReduceHp();
        }
    }
}
