using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginController : MonoBehaviour
{
    public TMP_InputField UserName;
    public TMP_InputField Password;

    public void Login()
    {
        string userPath = Application.dataPath + "/Data/UserData.json";

        UserData existingUser = UserExists(UserName.text, Password.text);

        if (existingUser != null)
        {
            string json = JsonUtility.ToJson(existingUser);
            File.WriteAllText(userPath, json);

            SceneManager.LoadScene("SampleScene");
        }
    }

    private UserData UserExists(string username, string password)
    {
        string usersPath = Application.dataPath + "/Data/UsersData.json";

        if (File.Exists(usersPath))
        {
            string[] lines = File.ReadAllLines(usersPath);

            foreach (string line in lines)
            {
                UserData userData = JsonUtility.FromJson<UserData>(line);
                if (userData != null && userData.UserName == username && userData.Password == password)
                {
                    // Username and password combination already exists
                    return userData;
                }
            }
        }

        return null;
    }
}
