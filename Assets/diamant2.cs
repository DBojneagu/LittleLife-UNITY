using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Diamant2 : MonoBehaviour
{
    int coins = 0;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Coin")
        {
            Debug.Log("Coin collided with the character.");
            coins++;
            Debug.Log(coins);
            Destroy(collision.gameObject);
        }
        Debug.Log("Coin not collided with the character.");
    }

    public void AddCoins()
    {
        int coinsToAdd = PlayerPrefs.GetInt("EarnedCoins", 0);
        coins += coinsToAdd;
        PlayerPrefs.DeleteKey("EarnedCoins");
        PlayerPrefs.Save();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if it's the initial scene (change "YourInitialSceneName" to the actual name of your initial scene)
        if (scene.name == "YourInitialSceneName")
        {
            // Call the AddCoins method when the initial scene is loaded
            AddCoins();
        }
    }
}
