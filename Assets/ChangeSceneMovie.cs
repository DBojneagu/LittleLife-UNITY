using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneMovie : MonoBehaviour
{
    public string sceneToLoad;
    public Button sceneChangeButton;
    // Start is called before the first frame update
    void Start()
    {
        sceneChangeButton.onClick.AddListener(ChangeScene);
    }

    // Update is called once per frame
    void ChangeScene()
    {

        // Load the specified scene
        SceneManager.LoadScene(sceneToLoad);
    }

}
