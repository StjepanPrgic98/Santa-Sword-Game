using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] Animator animator;

    [Header("Variables")]
    [SerializeField] float moveSpeed = 5;


    Vector2 moveInput;

    void Update()
    {
        Run();
        FlipSprite();
    }

    void Run()
    {
        rigidBody.velocity = moveInput * moveSpeed;
    }

    void FlipSprite()                           
    {
        bool playerIsMoving = Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon;
        if (playerIsMoving)
        {
            transform.localScale = new Vector2(Mathf.Sign(rigidBody.velocity.x), 1f);
        }

        TriggerWalkingAnimation(rigidBody.velocity);
    }

    void TriggerWalkingAnimation(Vector3 playerVelocity)
    {
        if(playerVelocity.x == 0 && playerVelocity.y == 0)
        {
            animator.SetBool("isWalking", false);
        }
        if(playerVelocity.x != 0 ||playerVelocity.y != 0)
        {
            animator.SetBool("isWalking", true);
        }
    }

    public void IncreaseMoveSpeed(float ammount)
    {
        moveSpeed += ammount;
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
