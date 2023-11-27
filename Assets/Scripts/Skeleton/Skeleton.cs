using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Animator animator;
    [SerializeField] CapsuleCollider2D capsuleCollider;

    [Header("Variables")]
    [SerializeField] float DestroySkeletonTime;   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Present")
        {
            DestroySkeleton();
            IncreaseSkeletonKillCountForRandomPowerup();     
        }
    }

    void DestroySkeleton()
    {
        capsuleCollider.enabled = false;
        Destroy(gameObject, DestroySkeletonTime);
        PlayDeathAnimation();
    }

    void PlayDeathAnimation()
    {
        animator.SetBool("isDead", true);
    }

    void IncreaseSkeletonKillCountForRandomPowerup()
    {
        FindObjectOfType<KillPowerup>().KillSkeleton();
    }
}
