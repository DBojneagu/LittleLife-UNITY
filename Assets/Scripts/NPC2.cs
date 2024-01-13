using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2 : MonoBehaviour
{
    private float speed = 2.5f;
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Debug.Log(transform.position);

        if (transform.position.z >= 40f)
        {
            transform.Rotate(0, -90 * Time.deltaTime, (float)Space.World);
        }

        if (transform.position.z <= 3f)
        {
            transform.Rotate(0, -90 * Time.deltaTime, (float)Space.World);
        }

    }
}
