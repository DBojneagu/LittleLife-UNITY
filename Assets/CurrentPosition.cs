using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPositionHandler : MonoBehaviour
{
    private Vector3 initialPosition; // Store the initial position

    private void Start()
    {
        // Save the initial position when the script starts
        initialPosition = transform.position;
    }

    // Save the player's position before transitioning to another scene
    public void SavePlayerPosition()
    {
        PlayerPrefs.SetFloat("PlayerPosX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", transform.position.z);
    }

    // Restore the player's position when returning to the original scene
    public void RestorePlayerPosition()
    {
        float savedPosX = PlayerPrefs.GetFloat("PlayerPosX", initialPosition.x);
        float savedPosY = PlayerPrefs.GetFloat("PlayerPosY", initialPosition.y);
        float savedPosZ = PlayerPrefs.GetFloat("PlayerPosZ", initialPosition.z);

        transform.position = new Vector3(savedPosX, savedPosY, savedPosZ);
    }
}
