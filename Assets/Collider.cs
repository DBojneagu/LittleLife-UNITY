using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovieCollider : MonoBehaviour
{
    [Header("Cinema Game Scene")]
    public SceneAsset cinemaGameSceneAsset; // Reference to the Cinema Game scene

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LoadCinemaGameScene();
        }
    }

    private void LoadCinemaGameScene()
    {
        if (cinemaGameSceneAsset != null)
        {
            string sceneName = cinemaGameSceneAsset.name;
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Cinema Game Scene Asset is not assigned.");
        }
    }
}
