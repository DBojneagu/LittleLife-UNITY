using UnityEngine;

public class gameMain : MonoBehaviour
{
    public Transform playerTransform;
    private void Start()
    {
        // Load character position
        float playerX = PlayerPrefs.GetFloat("PlayerX", 16f);
        float playerY = PlayerPrefs.GetFloat("PlayerY", 0f);
        float playerZ = PlayerPrefs.GetFloat("PlayerZ", -9f);

        // Set the player's position
        playerTransform.position = new Vector3(playerX, playerY, playerZ);
    }
    private void OnDestroy()
    {
        // Save character position before changing scenes
        PlayerPrefs.SetFloat("PlayerX", playerTransform.position.x);
        PlayerPrefs.SetFloat("PlayerY", playerTransform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", playerTransform.position.z);
        PlayerPrefs.Save();
    }
}