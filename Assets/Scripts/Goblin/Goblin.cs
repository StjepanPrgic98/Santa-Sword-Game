using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Animator animator;

    ChristmasTree christmasTree;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Present")
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
        Invoke(nameof(Destroy), 0.5f);
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
            if(christmasTree.GetHp() <= 0) { SetAttackAnimation(false); PlayDeathAnimation(); break; }
            christmasTree.ReduceHp();
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
