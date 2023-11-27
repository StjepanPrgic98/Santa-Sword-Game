using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Rigidbody2D rigidBody;

    [Header("Variables")]
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 targetPosition;

    Vector3 direction;

    void Update()
    {
        MoveTowardsTargetPosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ChristmasTree")
        {
            rigidBody.isKinematic = true;
            this.enabled = false;
        }
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
}
