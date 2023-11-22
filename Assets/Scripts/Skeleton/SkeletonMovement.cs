using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] SpriteRenderer spriteRenderer;

    [Header("Variables")]
    [SerializeField] float moveSpeed = 5f;

    Transform playerTransform;
    
    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
       
        Vector3 directionToPlayer = playerTransform.position - transform.position;
        directionToPlayer.Normalize();
        transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime);

        FlipSprite(directionToPlayer.x);
        
        
    }

    void FlipSprite(float direction)
    {
        if (direction > 0)
        {
            spriteRenderer.flipX = false; 
        }
        else if (direction < 0)
        {
            spriteRenderer.flipX = true; 
        }
    }
}
