using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeController : MonoBehaviour
{
    public void NewGame()
    {
        string userPath = Application.dataPath + "/Data/UserData.json";

        UserData user = new UserData();
        string json = JsonUtility.ToJson(user, true);
        File.WriteAllText(userPath, json);

        SceneManager.LoadScene("SampleScene");
    }
}
