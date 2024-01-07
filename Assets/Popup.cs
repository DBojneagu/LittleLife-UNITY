using UnityEngine;
using UnityEngine.UI;

public class MissionPopup : MonoBehaviour
{
    public Q1 taskCompletion;
    public Q2 taskCompletion2;
    public GameObject popupPanel;
    

    void Start()
    {
        // Deactivate the popup panel on start
        popupPanel.SetActive(false);
    }

    public void TogglePopup()
    {
        // Toggle the popup panel's active state
        //taskCompletion.BlurTask();
        taskCompletion.SelectTask();
        //taskCompletion2.SelectTask();
        popupPanel.SetActive(!popupPanel.activeSelf);

    }
}
