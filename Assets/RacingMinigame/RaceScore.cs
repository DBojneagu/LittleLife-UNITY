using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class RaceScore : MonoBehaviour
{
    private int score = 500;

    [SerializeField]
    private TextMeshProUGUI scoreUI;

    [SerializeField]
    private TextMeshProUGUI finalScoreUI;

    public GameObject panel;

    public string sceneToLoad;

    public Button sceneChangeButton;
    void Start()
    {
        sceneChangeButton.onClick.AddListener(ChangeScene);
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    void Update()
    {
        scoreUI.text = "Score: " + score.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Rail")
        {
            score -= 20;
            scoreUI.text = "Score: " + score.ToString();
        }

        if(other.gameObject.tag == "Finish")
        {
            panel.SetActive(true);
            finalScoreUI.text = score.ToString() + " Diamonds";
            PlayerPrefs.SetInt("PointsRace", score);
            //SceneManager.LoadScene("WelcomeScene");
        }
    }
}
