using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaMovement : MonoBehaviour
{
    public float speed = 5f; // Adjust this value to set the player's movement speed.

    void Update()
    {
        // Get input from the arrow keys or WASD keys.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement vector.
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // Normalize the movement vector to ensure consistent speed in all directions.
        movement.Normalize();

        // Move the player using Rigidbody2D.
        MovePlayer(movement);
    }

    void MovePlayer(Vector2 movement)
    {
        // Access the Rigidbody2D component attached to the player GameObject.
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Check if there is any input. If not, set velocity to zero.
        if (movement != Vector2.zero)
        {
            // Move the player by adding a force to the Rigidbody2D.
            rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
        }
        else
        {
            // If no input, stop the player.
            rb.velocity = Vector2.zero;
        }
    }
}
