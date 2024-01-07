using UnityEngine;

public class BuyCharacter : MonoBehaviour
{
    // Assume the user's initial money
    private int userMoney = 25; // You can set this to the user's actual money amount

    public void BuyCharacter1()
    {
        BuyCharacters("Bird", 10);
    }

    // Function to handle Character2 button click
    public void BuyCharacter2()
    {
        BuyCharacters("Monkey", 20);
    }

    // Function to handle Character3 button click
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

    // Function to handle character button clicks
    public void BuyCharacters(string characterName, int characterPrice)
    {
        if (userMoney >= characterPrice)
        {
            // User has enough money to buy the character
            Debug.Log($"Congratulations! You bought {characterName} for ${characterPrice}.");
            userMoney -= characterPrice; // Deduct the money after purchase
        }
        else
        {
            // User doesn't have enough money, display an alert or message
            Debug.Log("Not enough money to buy this character!");
        }
    }
}
