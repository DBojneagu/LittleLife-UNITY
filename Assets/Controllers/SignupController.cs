using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEngine.Debug;
using UnityEngine.UI;
using static UnityEngine.Application;
using UnityEngine.SceneManagement;
using TMPro;

public class SignupController : MonoBehaviour
{
    public TMP_InputField UserName;
    public TMP_InputField Password;

    public void SignUp()
    {
        string filePath = Application.dataPath + "/Data/UsersData.json";

        if (!UsernameExists(UserName.text, filePath))
        {
            UserData data = new UserData();
            data.UserName = UserName.text;
            data.Password = Password.text;

            string json = $"{{\"UserName\":\"{data.UserName}\",\"Password\":\"{data.Password}\",\"Score\":{"0"},\"SelectedCharacter\":{"1"},\"Characters\":[{"1"}]}}";

            if (File.Exists(filePath))
            {
                File.AppendAllText(filePath, "\n" + json);
            }
            else
            {
                File.WriteAllText(filePath, json);
            }

            SceneManager.LoadScene("LoginScene");
        }
    }

    private bool UsernameExists(string newUsername, string filePath)
    {
        if (File.Exists(filePath))
        {
            string[] existingUsernames = File.ReadAllLines(filePath);

            foreach (string line in existingUsernames)
            {
                UserData userData = JsonUtility.FromJson<UserData>(line);
                if (userData != null && userData.UserName == newUsername)
                {
                    // Username already exists
                    return true;
                }
            }
        }

        // Username doesn't exist
        return false;
    }
}
