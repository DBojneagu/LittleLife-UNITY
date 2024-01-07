using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static GameObject currentCharacter;

    private void Start()
    {
        // Example: Initialize currentCharacter by finding the initial character in the scene
        currentCharacter = GameObject.FindWithTag("Player");
    }

    public static void SetCurrentCharacter(GameObject newCharacter)
    {
        currentCharacter = newCharacter;
    }

    public static void SwitchCharacter(GameObject newCharacterPrefab)
    {
        Debug.LogWarning("entered switch!");

        Debug.LogWarning(newCharacterPrefab.name);

        if (newCharacterPrefab != null)
        {
            // Instantiate the new character prefab
            GameObject newCharacter = Instantiate(newCharacterPrefab, Vector3.zero, Quaternion.identity);

            // Optionally, copy the position and rotation from the current character to the new character
            if (currentCharacter != null)
            {
                newCharacter.transform.position = currentCharacter.transform.position;
                newCharacter.transform.rotation = currentCharacter.transform.rotation;
            }

            // Destroy the current character GameObject
            Destroy(currentCharacter);

            // Set the new character as the current character
            SetCurrentCharacter(newCharacter);
        }
        else
        {
            Debug.LogWarning("New character prefab not assigned!");
        }
    }
}
