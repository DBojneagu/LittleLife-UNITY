using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RaceScore : MonoBehaviour
{
    private int score = 500;

    [SerializeField]
    private TextMeshProUGUI scoreUI;

    // public GameOverScreen gameOverScreen;

    void Update()
    {
        scoreUI.text = "Score: " + score.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Rail")
        {
            score -= 20;
        }

        if(other.gameObject.tag == "Finish")
        {
            // gameOverScreen.Setup(score);
            SceneManager.LoadScene("WelcomeScene");
        }
    }
}
