using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Animator animator;
    [SerializeField] CapsuleCollider2D capsuleCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Present" || collision.tag == "Player")
        {
            PlayDeathAnimation();
            Destroy(gameObject, 1);
            FindObjectOfType<KillPowerup>().KillSkeleton();
        }
    }

    void PlayDeathAnimation()
    {
        animator.SetBool("isDead", true);
        capsuleCollider.enabled = false;
    }
}
