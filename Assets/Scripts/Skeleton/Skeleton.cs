using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Present")
        {
            PlayDeathAnimation();
            Destroy(gameObject, 1);
        }
    }

    void PlayDeathAnimation()
    {
        animator.SetBool("isDead", true);
    }
}
