using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject welcomePanel;
    public GameObject quizPanel;
    public GameObject gameOverPanel;
    public Text scoreText;

    private int playerScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Show the welcome panel at the start
        ActivatePanel(welcomePanel);
    }

    // Call this method to start the quiz
    public void StartQuiz()
    {
        // Hide the welcome panel and show the quiz panel
        DeactivatePanel(welcomePanel);
        ActivatePanel(quizPanel);

        // Reset the score at the start of the quiz
        playerScore = 0;
    }

    // Call this method to end the quiz
    public void EndQuiz()
    {
        // Hide the quiz panel and show the game over panel
        DeactivatePanel(quizPanel);
        ActivatePanel(gameOverPanel);

        // Display the player's score
        scoreText.text = "Score: " + playerScore;
    }

    // Call this method when the player answers a question correctly
    public void CorrectAnswer()
    {
        // Increment the player's score
        playerScore++;
    }

    // Helper method to activate a panel
    private void ActivatePanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    // Helper method to deactivate a panel
    private void DeactivatePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
}
