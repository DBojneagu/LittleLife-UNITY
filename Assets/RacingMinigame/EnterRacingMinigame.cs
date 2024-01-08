using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterRacingMinigame : MonoBehaviour
{
    public string sceneToLoad;
    public PlayerPositionHandler playerPositionHandler;
    public Transform playerTransform;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ferrari"))
        {
            PlayerPrefs.Save();
            // Save the player's position before transitioning to another scene
            playerPositionHandler.SavePlayerPosition();
            PlayerPrefs.SetFloat("PlayerX", playerTransform.position.x);
            PlayerPrefs.SetFloat("PlayerY", playerTransform.position.y);
            PlayerPrefs.SetFloat("PlayerZ", playerTransform.position.z);
            PlayerPrefs.Save();
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
