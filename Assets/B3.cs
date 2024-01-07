using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActivation3 : MonoBehaviour
{
    public Button myButton;

    // Start is called before the first frame update
    void Awake()
    {
        // Set the button as inactive when the scene starts
        myButton.gameObject.SetActive(false);
        myButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        gameObject.SetActive(false);
        int nrcoins = PlayerPrefs.GetInt("EarnedCoins");
        nrcoins += 50;
        PlayerPrefs.SetInt("EarnedCoins", nrcoins);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("CompletedClaimSnake", 1);
        PlayerPrefs.Save();
    }

    // This method will be called when the button is clicked
    public void ActivateButton()
    {
        gameObject.SetActive(true);
    }
    public void DezActivateButton()
    {
        myButton.gameObject.SetActive(false);
    }
    public void ToggleButton()
    {
        myButton.gameObject.SetActive(false);
    }
}
