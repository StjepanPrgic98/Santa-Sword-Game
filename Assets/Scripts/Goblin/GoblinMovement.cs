using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] SpriteRenderer spriteRenderer;

    [Header("Variables")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Vector3 targetPosition = new Vector3(-1.565f, -0.7399999f);

    Vector3 direction;

    void Update()
    {
        MoveTowardsTargetPosition();
    }

    void MoveTowardsTargetPosition()
    {
        direction = targetPosition - transform.position;
        direction.Normalize();

        transform.Translate(direction * moveSpeed * Time.deltaTime);

        if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ChristmasTree")
        {
            this.enabled = false;
        }
    }
}
