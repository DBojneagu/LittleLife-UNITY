using UnityEngine;

public class BuyCharacter : MonoBehaviour
{
    private int userMoney = 25; // Initial user money

    public GameObject newCharacterPrefab; // Reference to the prefab of the new character

    private CharacterManager characterManager; // Reference to the CharacterManager script

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
        BuyCharacters("Bird", 10);
    }

    public void BuyCharacter2()
    {
        BuyCharacters("Monkey", 20);
    }

    public void BuyCharacter3()
    {
        BuyCharacters("Squid", 30);
    }

    public void BuyCharacter4()
    {
        BuyCharacters("Deer", 40);
    }

    public void BuyCharacter5()
    {
        BuyCharacters("Snake", 50);
    }

    public void BuyCharacter6()
    {
        BuyCharacters("Mouse", 60);
    }

    public void BuyCharacter7()
    {
        BuyCharacters("Gecko", 70);
    }

    public void BuyCharacter8()
    {
        BuyCharacters("Fish", 80);
    }

    public void BuyCharacters(string characterName, int characterPrice)
    {
        if (userMoney >= characterPrice && characterManager != null)
        {
            // User has enough money to buy the character
            Debug.Log($"Congratulations! You bought {characterName} for ${characterPrice}.");
            userMoney -= characterPrice; // Deduct the money after purchase
            CharacterManager.SwitchCharacter(newCharacterPrefab);
        }
        else
        {
            // User doesn't have enough money or CharacterManager is not initialized
            Debug.Log("Not enough money to buy this character or CharacterManager is not initialized!");
        }
    }
}
