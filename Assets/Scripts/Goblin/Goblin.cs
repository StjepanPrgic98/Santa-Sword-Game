using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Present")
        {
            animator.SetBool("isDead", true);
            Invoke(nameof(Destroy), 0.5f);
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
