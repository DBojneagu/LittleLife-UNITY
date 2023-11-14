using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed

    void Update()
    {
        // Input for horizontal and vertical movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Check if there's actual input (prevents diagonal movement from being faster)
        if (movement != Vector3.zero)
        {
            // Rotate the character to face the movement direction
            transform.rotation = Quaternion.LookRotation(movement);

            // Move the character
            transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}

