using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The character's Transform (Player GameObject)

    public Vector3 offset; // The offset between the camera and the character

    void Update()
    {
        if (target == null)
        {
            return; // If the target is not set, do nothing.
        }

        // Update the camera's position to follow the character with the defined offset
        transform.position = target.position + offset;
    }
}

