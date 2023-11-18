using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamant2 : MonoBehaviour
{
    // Other variables and functions of the script
    int coins = 0;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag=="Coin")
        {
            // Destroy the coin when the character touches it
            Debug.Log("Coin collided with the character.");
            coins++;
            Debug.Log(coins);
            Destroy(collision.gameObject);
        }
        Debug.Log("Coin no with the character.");
    }
}