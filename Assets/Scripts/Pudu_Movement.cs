using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public AudioSource audioSource;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 localMovement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        Vector3 worldMovement = transform.TransformDirection(localMovement);

        if (worldMovement != Vector3.zero)
        {
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
            // Check if audioSource is not null and the footstep sound is playing, then stop it
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
