using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    //public List<Quest> questList;
    public int numberOfQuestsToShow = 3;
    public TextMeshPro[] questTexts; // Reference to Text UI elements on your panel
    void Awake()
    {
        questTexts = new TextMeshPro[numberOfQuestsToShow];
        Debug.Log("questTexts length: " + questTexts.Length);
    }
    void Start()
    {
        InitializeQuests();
        FindQuestTexts();
        DisplayQuests();
    }

    void FindQuestTexts()
    {
        // Assuming the panel GameObject is named "QuestPanel"
        GameObject questPanel = GameObject.Find("Panel");

        if (questPanel != null)
        {
            questTexts = questPanel.GetComponentsInChildren<TextMeshPro>();
        }
        else
        {
            Debug.LogError("QuestPanel not found. Make sure the panel GameObject is named 'QuestPanel'.");
        }
    }

    void InitializeQuests()
    {
        
    }

    void DisplayQuests()
    {
        
        // Display random quests on the panel
        int cnt = 0;
        for (int i = 0; i < numberOfQuestsToShow; i++)
        {
            //int randomIndex = Random.Range(0, questList.Count);
            //if (questList[i].isSelected == false)
            //{
            //    questTexts[cnt].text = questList[i].questName + "\n" + questList[i].questDescription;
            //    questList[i].isSelected = true;
            //    Debug.Log(questTexts[cnt].text);
            //    cnt++;
            //}
            //else
            //{
            //    i--;
            //}
        }
    }

    public void CompleteQuest(string questName)
    {
        // Mark the quest as completed
        //Quest quest = questList.Find(q => q.questName == questName);
        //if (quest != null)
        //{
        //    DisplayQuests();
        //}
    }
}
