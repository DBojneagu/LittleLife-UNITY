using UnityEngine;

public class BuyCharacter : MonoBehaviour
{
    private int userMoney = 500; // Initial user money
    private CharacterManager characterManager; // Reference to the CharacterManager script
    public GameObject bird;
    public GameObject gecko;
    public GameObject deer;
    public GameObject monkey;
    public GameObject fish;
    public GameObject mouse;
    public GameObject squid;
    public GameObject snake;


    private void Start()
    {
        // Find the CharacterManager script in the scene
        characterManager = FindObjectOfType<CharacterManager>();

        if (characterManager == null)
        {
            Debug.LogError("CharacterManager not found in the scene!");
        }
    }

    public void BuyCharacter1()
    {
        BuyCharacters("Bird", 50, bird);
    }

    public void BuyCharacter2()
    {
        BuyCharacters("Monkey", 100, monkey);
    }

    public void BuyCharacter3()
    {
        BuyCharacters("Squid", 350, squid);
    }

    public void BuyCharacter4()
    {
        BuyCharacters("Deer", 0, deer);
    }

    public void BuyCharacter5()
    {
        BuyCharacters("Snake", 200, snake);
    }

    public void BuyCharacter6()
    {
        BuyCharacters("Mouse", 150, mouse);
    }

    public void BuyCharacter7()
    {
        BuyCharacters("Gecko", 300, gecko);
    }

    public void BuyCharacter8()
    {
        BuyCharacters("Fish", 250, fish);
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
/*            else
            {
                // If no specific character is provided, use the default newCharacterPrefab
                characterManager.SwitchCharacter(newCharacterPrefab);
            }*/
        }
        else
        {
            // User doesn't have enough money or CharacterManager is not initialized
            Debug.Log("Not enough money to buy this character or CharacterManager is not initialized!");
        }
    }
}
