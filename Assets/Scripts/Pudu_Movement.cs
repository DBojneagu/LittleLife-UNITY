using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public AudioSource audioSource;

    private Animator animator;  // Reference to the Animator component
    private bool isWalking;     // Flag to track whether the character is walking or not

    void Start()
    {
        // Get the Animator component attached to the same GameObject
        animator = GetComponent<Animator>();

        // Check if animator is not null (make sure you have Animator component attached to the GameObject)
        if (animator == null)
        {
            Debug.LogError("Animator component not found!");
        }
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 localMovement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        Vector3 worldMovement = transform.TransformDirection(localMovement);

        if (worldMovement != Vector3.zero)
        {
            isWalking = true;  // Set the flag to true when there's movement

            Quaternion targetRotation = Quaternion.LookRotation(worldMovement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.Translate(worldMovement * moveSpeed * Time.deltaTime, Space.World);

            // Check if audioSource is not null and the footstep sound is not already playing
            if (audioSource != null && !audioSource.isPlaying)
            {
                // Play the footstep sound
                audioSource.Play();
            }
        }
        else
        {
            isWalking = false;  // Set the flag to false when there's no movement

            // Check if audioSource is not null and the footstep sound is playing, then stop it
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }

            // Set IsSitting to true when not moving
            if (animator != null)
            {
                animator.SetBool("IsSitting", true);
            }
        }

        // Update the Animator parameter based on the isWalking flag
        if (animator != null)
        {
            animator.SetBool("IsWalking", isWalking);
        }
    }
}
