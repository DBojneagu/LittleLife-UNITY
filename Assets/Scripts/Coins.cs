using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int _countCoins = 0;
    public void AddCoins(int countCoins)
    {
        int earnedCoins = PlayerPrefs.GetInt("EarnedCoins", 0);
        _countCoins += earnedCoins;
        Debug.Log("COINSSSSSSS"+_countCoins);
    }
}
