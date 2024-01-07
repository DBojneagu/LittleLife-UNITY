using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class CoinCollision : MonoBehaviour
{

    private Rigidbody _rigidbody;
    public float _respawnTime = 5.0f;
    //private int _countCoins =PlayerPrefs.GetInt("EarnedCoins");
    public TextMeshProUGUI score;

    private void Awake() =>
        _rigidbody = GetComponent<Rigidbody>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {


            // Increment coin count
            int nrcoins= PlayerPrefs.GetInt("EarnedCoins");
            //nrcoins++;
           nrcoins++;
            PlayerPrefs.SetInt("EarnedCoins", nrcoins);
            PlayerPrefs.Save();
            //Debug.Log(_countCoins);

            // Disable the coin
            other.gameObject.SetActive(false);

            // Start a coroutine to wait for 3 seconds and then enable the coin
            StartCoroutine(EnableCoinAfterDelay(_respawnTime, other));
        }
    }

    private IEnumerator EnableCoinAfterDelay(float delay, Collider other)
    {
        // Wait for the specified time
        yield return new WaitForSeconds(delay);

        // Enable the coin and make it visible
        other.gameObject.SetActive(true);
    }

    private void Update()
    {
        int nrcoins = PlayerPrefs.GetInt("EarnedCoins");
        score.text = "Balance: " + nrcoins.ToString();
    }

}

