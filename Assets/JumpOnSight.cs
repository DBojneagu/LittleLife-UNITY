using UnityEngine;

public class JumpOnSight : MonoBehaviour
{
    public float jumpForce = 5f;
    public float timeBetweenJumps = 2f; // Time between consecutive jumps

    private bool canJump = true;

    void Update()
    {
        if (IsObjectVisible() && canJump)
        {
            Jump();
        }
    }

    bool IsObjectVisible()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        bool isVisible = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        return isVisible;
    }

    void Jump()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, jumpForce, 0);

        // Disable jumping temporarily
        canJump = false;

        // Wait for the specified time and enable jumping again
        Invoke("EnableJump", timeBetweenJumps);
    }

    void EnableJump()
    {
        canJump = true;
    }
}
