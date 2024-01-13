using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC3 : MonoBehaviour
{
    private float speed = 2.5f;
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Debug.Log(transform.position);

        if (transform.position.x >= 27f)
        {
            transform.Rotate(0, -90 * Time.deltaTime, (float)Space.World);
        }

        if (transform.position.x <= -37f)
        {
            transform.Rotate(0, -90 * Time.deltaTime, (float)Space.World);
        }


    }
}
