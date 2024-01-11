using UnityEngine;

public class BuyCharacter : MonoBehaviour
{
    private int userMoney = 25; // Initial user money
    public GameObject newCharacterPrefab; // Reference to the prefab of the new character
    private CharacterManager characterManager; // Reference to the CharacterManager script
    public GameObject bird;
    public GameObject gecko;
    public GameObject deer;

    private void Start()
    {
        // Find the CharacterManager script in the scene
        characterManager = FindObjectOfType<CharacterManager>();

        Debug.Log(newCharacterPrefab.name);

        if (characterManager == null)
        {
            Debug.LogError("CharacterManager not found in the scene!");
        }
    }

    public void BuyCharacter1()
    {
        BuyCharacters("Bird", 10, bird);
    }

    public void BuyCharacter2()
    {
        BuyCharacters("Monkey", 20, null);
    }

    public void BuyCharacter3()
    {
        BuyCharacters("Squid", 30, null);
    }

    public void BuyCharacter4()
    {
        BuyCharacters("Deer", 10, deer);
    }

    public void BuyCharacter5()
    {
        BuyCharacters("Snake", 50, null);
    }

    public void BuyCharacter6()
    {
        BuyCharacters("Mouse", 60, null);
    }

    public void BuyCharacter7()
    {
        BuyCharacters("Gecko", 10, gecko);
    }

    public void BuyCharacter8()
    {
        BuyCharacters("Fish", 80, null);
    }

    private void BuyCharacters(string characterName, int characterPrice, GameObject specificCharacter)
    {
        if (userMoney >= characterPrice && characterManager != null)
        {
            // User has enough money to buy the character
            Debug.Log($"Congratulations! You bought {characterName} for ${characterPrice}.");
            userMoney -= characterPrice; // Deduct the money after purchase

            if (specificCharacter != null)
            {
                // If a specific character is provided, switch to that character
                characterManager.SwitchCharacter(specificCharacter);
            }
            else
            {
                // If no specific character is provided, use the default newCharacterPrefab
                characterManager.SwitchCharacter(newCharacterPrefab);
            }
        }
        else
        {
            // User doesn't have enough money or CharacterManager is not initialized
            Debug.Log("Not enough money to buy this character or CharacterManager is not initialized!");
        }
    }
}
