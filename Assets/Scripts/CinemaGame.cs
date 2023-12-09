using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CinemaGame : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public TextMeshProUGUI questionText;  // Change from TextMesh to Text
        public string[] answers;
        public int correctAnswerIndex;
    }

    [SerializeField]
    public TextMeshProUGUI questionText;  // Change from TextMesh to Text
    [SerializeField]
    public Button[] answerButtons;

    private Question[] questions;
    private int currentQuestionIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Load questions (you can load them from a scriptable object or another source)
        questions = LoadQuestions();

        // Display the first question
        DisplayQuestion();
    }

    private void DisplayQuestion()
    {

        // Check if there are still questions
        if (currentQuestionIndex < questions.Length)
        {
            // Display the question text
            questionText.text = questions[currentQuestionIndex].questionText.text;

            // Display answer choices
            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = questions[currentQuestionIndex].answers[i];

            }

        }
        else
        {
            // No more questions, quiz is complete
            Debug.Log("Quiz Complete!");
        }
    }

    public void CheckAnswer(int buttonIndex)
    {
        // Check if the selected answer is correct
        if (questions[currentQuestionIndex].correctAnswerIndex == buttonIndex)
        {
            Debug.Log("Correct!");
        }
        else
        {
            Debug.Log("Incorrect!");
        }

        // Move to the next question
        currentQuestionIndex++;
        DisplayQuestion();
    }


    private Question[] LoadQuestions()
    {

        TextMeshProUGUI questionText1 = Instantiate(questionText);
        TextMeshProUGUI questionText2 = Instantiate(questionText);


        Question myQuestion1 = new Question();
        myQuestion1.questionText = questionText1; // Assign the reference from the inspector
        myQuestion1.questionText.text = "CE mancam azi";
        myQuestion1.answers = new string[] { "Berlin", "Madrid", "Paris", "Rome" };
        myQuestion1.correctAnswerIndex = 2;

        Question myQuestion2 = new Question();
        myQuestion2.questionText = questionText2; // Assign the reference from the inspector
        myQuestion2.questionText.text = "What is the capital of Romania?";
        myQuestion2.answers = new string[] { "Berlin", "Madrid", "Paris", "Bucharest" };
        myQuestion2.correctAnswerIndex = 3;

        Debug.Log("Question 1: " + myQuestion1.questionText.text);
        Debug.Log("Question 2: " + myQuestion2.questionText.text);


        Question[] res = { myQuestion1, myQuestion2 };

        return res;
    }




    public void OnOptionButtonClick(int buttonIndex)
    {
        CheckAnswer(buttonIndex);
    }


}
