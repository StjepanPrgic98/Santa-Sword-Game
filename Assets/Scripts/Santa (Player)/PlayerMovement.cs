using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Rigidbody2D rigidBody;

    
    Vector2 moveInput;
    float moveSpeed = 5;

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
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
